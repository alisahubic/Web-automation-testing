using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace JOliver
{

    [DataContract]
    public class BasicInformation
    {

       [DataMember(Name = "name")]
       public string Name { get; set; }

       
       [DataMember(Name = "username")]
       public string Username { get; set; }

       
       [DataMember(Name = "password")]
       public string Password { get; set; }
        

       [DataMember(Name = "birth_data")]
       public string BirthDate { get; set; }

       [DataMember(Name = "domain")]
       public string Domain { get; set; }
       
    }

    /*
    public class AdditionalInformation
    {

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "maiden_name")]
        public string MaidenName { get; set; }

        [DataMember(Name = "phone_h")]
        public string PhoneHome { get; set; }

        [DataMember(Name = "phone_w")]
        public string PhoneWork { get; set; }

        [DataMember(Name = "email_u")]
        public string EmailUsername { get; set; }

        [DataMember(Name = "email_d")]
        public string EmailDomain { get; set; }

        [DataMember(Name = "domain")]
        public static string Domain { get; set; }

        [DataMember(Name = "plasticcard")]
        public string CardNumber { get; set; }

        [DataMember(Name = "cardexpir")]
        public string CardExpire { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }       
    }

    */



}
