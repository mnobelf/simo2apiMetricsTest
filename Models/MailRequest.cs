using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simo2api.Helpers
{
    public class MailRequest
    {
        public ICollection<ToEmail> ? ToEmail { get; set; }
        public ICollection<CcEmail> ? CCEmail { get; set; }
        public ICollection<BccEmail>? BccEmail { get; set; }


        public string ? Subject { get; set; }
        public string ? Body { get; set; }
        public List<IFormFile> ? Attachments { get; set; }
    }
    public class GetRecipent
    {
        public ICollection<ToEmail> toEmails { get; set; }
    }
    public class ToEmail { 
        public string ? To { get; set; }
    }
    public class CcEmail
    {
        public string? Cc { get; set; }
    }
    public class BccEmail
    {
        public string? Bcc { get; set; }
    }
    public class RecipentEmail
    {
        public string? Email { get; set; }
    }
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
    public class EmailData
    {
        public string? Em_For { get; set; }
        public string? Em_Subject { get; set; }
        public string ? Em_To { get; set; }
        public string? Em_Cc { get; set; }
        public string? Em_Bcc { get; set; }
        public string? Em_Body { get; set; }
    }
    public class GetEmail
    {
        public string? Em_For { get; set; }
        public int UserID { get; set; }
        public string? CbDist { get; set; }
        public string DistId { get; set; }

    }
    public class LogNotifikasi
    {
        public int Type { get; set; }
        public int Success { get; set; }
        public string ? Mail { get; set; }
        public string ? UserName { get; set; }
        public string? Error { get; set; }
        public ICollection<ToEmail> ? LogTo { get; set; }
        public ICollection<CcEmail>? LogCc { get; set; }
        public ICollection<BccEmail>? LogBcc { get; set; }
    }
    public class GetEmailSend
    {
        public string ? MailTo { get; set; }
        public string? MailCc { get; set; }
        public string? MailBcc { get; set; }
    }
}