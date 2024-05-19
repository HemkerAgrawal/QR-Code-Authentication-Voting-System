using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteApi.Models;
using VoteApi.Data;

namespace VoteApi.Models
{
    public class ClassMail
    {

        public string name
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string dob
        {
            get;
            set;
        }
        public string phone
        {
            get;
            set;
        }
        public string fp
        {
            get;
            set;
        }
        public string address
        {
            get;
            set;
        }
        public string qr
        {
            get;
            set;
        }
        public string id
        {
            get;
            set;
        }
        public string vote
        {
            get;
            set;
        }
        public string extra1
        {
            get;
            set;
        }
    }
}
