﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PushNotificationServer.Models;

namespace PushNotificationServer.Controllers
{
    // let's determine where each web service is being implemented so that we can compare it against the docs
    public class DevicesController : ApiController
    {
        // GET request to webServiceURL/version/devices/deviceLibraryIdentifier/registrations/passTypeIdentifier
        // why the method overload?
        [HttpGet]
        public HttpResponseMessage GetSerialNumber(string deviceLibraryIdentifier, string passTypeIdentifier)
        {
            var response = new HttpResponseMessage();

            return response;
        }
        // GET request to webServiceURL/version/devices/deviceLibraryIdentifier/registrations/passTypeIdentifier?passesUpdatedSince=tag
        [HttpGet]
        public HttpResponseMessage GetSerialNumber(string deviceLibraryIdentifier, string passTypeIdentifier, string passesUpdatedSince)
        {
            // For example...
            SerialNumbers lastUpdateToSerialNumDict = new SerialNumbers();
            // LastUpdated timestamp set to current datetime
            lastUpdateToSerialNumDict.lastUpdated = String.Format("{0:MM/dd/yyyy HH:mm:ss}", DateTime.Now);
            // A list of serial numbers got from database
            // it looks like serialNumList wasn't defined in the example, let's go poke around the apple docs
            // SerialNumbers : An object that contains serial numbers for the updatable passes on a device.
            // I think I need to get the content for serialNumbers from users device
            lastUpdateToSerialNumDict.serialNumbers = serialNumList; // serialNumList was never defined, is it in the apple docs?
            string jsonRes = JsonConvert.SerializeObject(lastUpdateToSerialNumDict);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonRes, Encoding.UTF8, "application/json");
            return response;
        }
        // POST request to webServiceURL/version/devices/deviceLibraryIdentifier/registrations/passTypeIdentifier/serialNumber
        [HttpPost]
        public HttpResponseMessage RegisterDevice(string deviceLibraryIdentifier, string passTypeIdentifier, string serialNumber, [FromBody] ApplePassServiceData.DevicesPayload payload)
        {
            //Save to database, udpate Devices, Passes, Register table
            var response = new HttpResponseMessage();

            return response;
        }
        // DELETE request to webServiceURL/version/devices/deviceLibraryIdentifier/registrations/passTypeIdentifier/serialNumber
        [HttpDelete]
        public HttpResponseMessage UnRegisterDevice(string deviceLibraryIdentifier, string passTypeIdentifier, string serialNumber)
        {
            //Udpate Devices and Register table
            var response = new HttpResponseMessage();

            return response;
        }
    }
}