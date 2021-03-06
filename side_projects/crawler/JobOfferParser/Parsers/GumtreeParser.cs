﻿using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using HtmlAgilityPack;
using JobOfferParser.Data;
using JobOfferParser.Helpers;

namespace JobOfferParser.Parsers
{
    public class GumtreeParser : IParser
    {
        public Offer ParseOffer(HtmlNode node)
        {

            string link = node.SelectSingleNode("a[1]").Attributes["href"].Value;
            string title = node.SelectSingleNode("a[1]").InnerText;

            var offer = new Offer
            {
                Title = title,
                Link = link
            };

            var request = WebRequest.Create(offer.Link);

            using (var response = request.GetResponse().GetResponseStream())
            {
                var document = new HtmlDocument();
                document.Load(response, true);
              
                var body = document.DocumentNode.SelectSingleNode("//body");
                var date = body.SelectSingleNode("//td[@class='first_row']").InnerText.Trim().Substring(0,10).Replace("/", "-");
                var text = body.SelectSingleNode("//span[@id='preview-local-desc']").InnerText;
                var address = document.DocumentNode.SelectSingleNode("//meta[@property='og:locality']").Attributes["content"].Value;

                var provinceAndCity = address.Trim().Split('/');
                var province = provinceAndCity[0];
                var city = provinceAndCity[1];

                DateTime dateParsed;
                DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.CurrentUICulture.DateTimeFormat,
                                     DateTimeStyles.AllowWhiteSpaces, out dateParsed);


                
                offer.Text = text;
                offer.City = city;
                offer.Province = province;
                offer.Date = dateParsed;
                offer.Source = "Gumtree";

            }

            offer.Sha1 = OfferHelper.GenerateSha1(offer.Text);
            return offer;
        }
    }
}