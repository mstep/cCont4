using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.ComponentModel;

namespace cCont4
{
    public class Customer : IPerson, INotifyPropertyChanged, INotifyPropertyChanging
    {

        #region Members
        private int _id;
        private string _name;
        private DateTime _dob;
        private int _accountId;
        private DateTime _lastUpdated;
        private event PropertyChangedEventHandler _propertyChanged;
        private event PropertyChangingEventHandler _propertyChanging;
        #endregion

        /// <summary>
        /// Get/set the account id. Note that the account contract is explicitly set.
        /// </summary>
        public int AccountId
        {
            get { return _accountId; }
            set
            {
                Contract.Requires(value > 0);
                OnChanging("AccountId");
                _accountId = value;
                OnChanged("AccountId");
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return _lastUpdated;
            }
        }

        #region IPerson Members

        /// <summary>
        /// Get/set the id. Note that the account contract is inherited from <see cref="PersonContract"/>.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value) return;
                OnChanging("Id");
                _id = value;
                OnChanged("Id");
            }
        }

        /// <summary>
        /// Get/set the name. Note that the account contract is inherited from <see cref="PersonContract"/>.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value) return;
                OnChanging("Name");
                _name = value;
                OnChanged("Name");
            }
        }

        /// <summary>
        /// Get/set the date of birth. Note that the account contract is inherited from <see cref="PersonContract"/>.
        /// </summary>
        public DateTime DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                if (_dob == value) return;
                OnChanging("DOB");
                _dob = value;
                OnChanged("DOB");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }

        private void OnChanged(string name)
        {
            _lastUpdated = DateTime.Now;
            PropertyChangedEventHandler handler = _propertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangingEventHandler PropertyChanging
        {
            add { _propertyChanging += value; }
            remove { _propertyChanging -= value; }
        }

        private void OnChanging(string name)
        {
            PropertyChangingEventHandler handler = _propertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(name));
        }
    }
}
