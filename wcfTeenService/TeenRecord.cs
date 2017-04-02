using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DBreeze.DataTypes;
using wcfTeenService.DataClasses;

namespace wcfTeenService.wcf
{
    [DataContract(Name = "TeenRecord", Namespace = "")]
    public class TeenRecord
    {
        #region Private Fields
        private int _PublicRecId = -1;
        private int _PrivateRecId = -1;
        private string _FirstName = "";
        private string _LastName = "";
        private string _PhoneArea = "";
        private string _PhonePrefix = "";
        private string _PhoneSuffix = "";
        private string _Street1 = "";
        private string _Street2 = "";
        private string _City = "";
        private string _State = "";
        private string _Zip = "";
        private string _Sex = "";
        private string _Bus = "";
        private string _Grade = "";
        private string _GuestOf = "";
        private string _CheckIn = "";
        private string _Dirty = "";
        private string _NewRec = "";
        private string _UpdateRec = "";
        private string _UpdateCheckin = "";
        private string _GuestOfKey = "";
        #endregion
        #region Public Properties
        [DataMember(Name = "PublicRecId", Order = 1)]
        public int PublicRecId
        {
            get { return _PublicRecId; }
            set { _PublicRecId = value; }
        }
        [DataMember(Name = "PrivateRecId", Order = 2)]
        public int PrivateRecId
        {
            get { return _PrivateRecId; }
            set { _PrivateRecId = value; }
        }
        [DataMember(Name = "FirstName", Order = 3)]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [DataMember(Name = "LastName", Order = 4)]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [DataMember(Name = "PhoneArea", Order = 5)]
        public string PhoneArea
        {
            get { return _PhoneArea; }
            set { _PhoneArea = value; }
        }
        [DataMember(Name = "PhonePrefix", Order = 6)]
        public string PhonePrefix
        {
            get { return _PhonePrefix; }
            set { _PhonePrefix = value; }
        }
        [DataMember(Name = "PhoneSuffix", Order = 7)]
        public string PhoneSuffix
        {
            get { return PhoneSuffix; }
            set { _PhoneSuffix = value; }
        }
        [DataMember(Name = "Street1", Order = 8)]
        public string Street1
        {
            get { return _Street1; }
            set { _Street1 = value; }
        }
        [DataMember(Name = "Street2", Order = 9)]
        public string Street2
        {
            get { return _Street2; }
            set { _Street2 = value; }
        }
        [DataMember(Name = "City", Order = 10)]
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        [DataMember(Name = "State", Order = 11)]
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        [DataMember(Name = "Zip", Order = 12)]
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }
        [DataMember(Name = "Sex", Order = 13)]
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        [DataMember(Name = "Bus", Order = 14)]
        public string Bus
        {
            get { return _Bus; }
            set { _Bus = value; }
        }
        [DataMember(Name = "Grade", Order = 15)]
        public string Grade
        {
            get { return _Grade; }
            set { _Grade = value; }
        }
        [DataMember(Name = "GuestOf", Order = 16)]
        public string GuestOf
        {
            get { return _GuestOf; }
            set { _GuestOf = value; }
        }
        [DataMember(Name = "CheckIn", Order = 17)]
        public string CheckIn
        {
            get { return _CheckIn; }
            set { _CheckIn = value; }
        }
        [DataMember(Name = "Dirty", Order = 18)]
        public string Dirty
        {
            get { return _Dirty; }
            set { _Dirty = value; }
        }
        [DataMember(Name = "NewRec", Order = 18)]
        public string NewRec
        {
            get { return _NewRec; }
            set { _NewRec = value; }
        }
        [DataMember(Name = "UpdateRec", Order = 18)]
        public string UpdateRec
        {
            get { return _UpdateRec; }
            set { _UpdateRec = value; }
        }
        [DataMember(Name = "UpdateCheckin", Order = 18)]
        public string UpdateCheckin
        {
            get { return _UpdateCheckin; }
            set { _UpdateCheckin = value; }
        }
        [DataMember(Name = "GuestOfKey", Order = 18)]
        public string GuestOfKey
        {
            get { return _GuestOfKey; }
            set { _GuestOfKey = value; }
        }

        [IgnoreDataMember]
        public bool IsNewRec
        {
            get { return NewRec.ToUpper() == "Y"; }            
        }

        #endregion
        #region Constructor
        public TeenRecord()
        {
        }
        public TeenRecord(Teen r)
        {
            PopulateFromTeen(r);
        }
        #endregion
        #region Methods
        public void PopulateFromTeen(Teen r)
        {
            PublicRecId = r.id;
            FirstName = r.FirstName;
            LastName = r.LastName;
            PhoneArea = r.PhoneArea;
            PhonePrefix = r.PhonePrefix;
            PhoneSuffix = r.PhonePostfix;
            Street1 = r.Street1;
            Street2 = r.Street2;
            City = r.City;
            State = r.State;
            Zip = r.zip;
            Sex = r.Sex;
            Bus = r.Bus;
            Grade = r.Grade;
            GuestOf = r.GuestOf;
            GuestOfKey = r.GuestOfKey;
            CheckIn = r.lstAttendanceDates.Contains(DateTime.Today) ? "Y" : "N";
        }
        public Teen ToTeen()
        {
            var ret = new Teen();

            ret.id = PublicRecId;
            ret.FirstName = FirstName;
            ret.LastName = LastName;
            ret.PhoneArea = PhoneArea;
            ret.PhonePrefix = PhonePrefix;
            ret.PhonePostfix = PhoneSuffix;
            ret.Street1 = Street1;
            ret.Street2 = Street2;
            ret.City = City;
            ret.State = State;
            ret.zip = Zip;
            ret.Sex = Sex;
            ret.Bus = Bus;
            ret.Grade = Grade;
            ret.GuestOf = GuestOf;
            ret.GuestOfKey = GuestOfKey;            
            return ret;
        }


        public void Insert(Entity.TeenData.TeenDB db)
        {
            if(IsNewRec)
            {
                PublicRecId = Teen.GetNextKey();
                var Rec = ToTeen();                
            }

            using (var tran = Settings.Engine.GetTransaction())
            {
                if (IsNewRec)
                {

                }
                if (PublicRecId == -1) // new record
                {
                    var MaxRecord = tran.Max<int, DbMJSON<TeenRecord>>("Teens");
                    PublicRecId = MaxRecord?.Key ?? 0;  // If no records it defaults to 0...
                    PublicRecId++; // Get the next seed. :)
                }

                tran.Insert<int, DbMJSON<TeenRecord>>("Teens", PublicRecId, this);
                tran.Commit();
            }

            //    var rec = new Entity.TeenData.Teen()
            //    {
            //        FirstName = FirstName,
            //        LastName = LastName,
            //        PhoneArea = PhoneArea,
            //        PhonePrefix = PhonePrefix,
            //        PhonePostfix = PhoneSuffix,
            //        Street1 = Street1,
            //        Street2 = Street2,
            //        City = City,
            //        State = State,
            //        zip = Zip,
            //        Sex = Sex,
            //        Bus = Bus,
            //        Grade = Grade,
            //        GuestOf = GuestOf,
            //        GuestOfKey = GuestOfKey
            //    };

            //db.Teens.Add(rec);
        }

        public void Update()
        {
        }
        #endregion


    }


}