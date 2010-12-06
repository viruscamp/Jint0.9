﻿using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;
using System.Globalization;

namespace Jint.Native {
    [Serializable]
    public sealed class JsDate : JsObject {
        static internal long OFFSET_1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
        static internal int TICKSFACTOR = 10000;

        private DateTime value;

        public override object Value {
            get {
                return value;
            }
            set {
                if (value is DateTime)
                    this.value = (DateTime)value;
                else if (value is double)
                    this.value = new DateTime((double)value);
            }
        }

        public JsDate(JsObject prototype)
            : base(prototype) {
            value = 0;
        }

        public JsDate(DateTime date, JsObject prototype)
            : this((date.ToUniversalTime().Ticks - OFFSET_1970) / TICKSFACTOR, prototype) {
        }

        public JsDate(double value, JsObject prototype)
            : base(prototype) {
            this.value = value;
        }

        public override double ToNumber() {
            return value;
        }

        public static string FORMAT = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'zzz";
        public static string FORMATUTC = "ddd, dd MMM yyyy HH':'mm':'ss 'UTC'";
        public static string DATEFORMAT = "ddd, dd MMM yyyy";
        public static string TIMEFORMAT = "HH':'mm':'ss 'GMT'zzz";

        public static double DateToDouble(DateTime date) {
            return (date.ToUniversalTime().Ticks - OFFSET_1970) / TICKSFACTOR;
        }

        public override string ToString() {
            return JsDateConstructor.CreateDateTime(value).ToLocalTime().ToString(FORMAT, CultureInfo.InvariantCulture);
        }

        public override object ToObject() {
            return JsDateConstructor.CreateDateTime(value);
        }
        public const string TYPEOF = "object";

        public override string Class {
            get { return TYPEOF; }
        }
    }
}
