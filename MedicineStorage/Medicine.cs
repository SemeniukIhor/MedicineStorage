using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MedicineStorage
{
    [DataContract]
    public class Medicine: INotifyPropertyChanged
    {
        private string condition;
        private string nаme;
        private string unit;
        private int cams;
        private int go;
        private int still;
        private DateTime date;
        [DataMember]
        public string Condition
        {
            get { return condition; }
            set
            {
                if (condition == value)
                    return;
                condition = value;
                OnPropertyChanged("Condition");
            }
        }
        [DataMember]
        public string Name
        {
            get { return nаme; }
            set
            {
                if (nаme == value)
                    return;
                nаme = value;
                OnPropertyChanged("Name");
            }
        }
        [DataMember]
        public string Unit
        {
            get { return unit; }
            set
            {
                if (unit == value)
                    return;
                unit = value;
                OnPropertyChanged("Unit");
            }
        }
        [DataMember]
        public int Cams
        {
            get { return cams; }
            set
            {
                if (cams == value)
                    return;
                cams = value;
                OnPropertyChanged("Cams");
            }
        }
        [DataMember]
        public int Go
        {
            get { return go; }
            set
            {
                if (go == value)
                    return;
                go = value;
                OnPropertyChanged("Go");
            }
        }
        [DataMember]
        public int Still
        {
            get { return still; }
            set
            {
                if (still == value)
                    return;
                still = value;
                OnPropertyChanged("Still");
            }
        }
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date == value)
                    return;
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
