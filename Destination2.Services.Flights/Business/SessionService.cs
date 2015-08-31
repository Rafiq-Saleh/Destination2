using Destination2.Services.Flights.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;

namespace Destination2.Services.Flights.Business
{
    internal interface ISessionService
    {
        bool IsAvailable { get; }
        bool ItemExists(SessionEnum sessionServiceEnum);
        bool ItemExists(SessionEnum sessionServiceEnum, string suffix);
        void SetItem<T>(SessionEnum sessionServiceEnum, T objectToSave);
        void SetItem<T>(SessionEnum sessionServiceEnum, string suffix, T objectToSave);
        T GetItem<T>(SessionEnum sessionServiceEnum);
        T GetItem<T>(SessionEnum sessionServiceEnum, string suffix);
        bool RemoveItem(SessionEnum sessionServiceEnum);
        bool RemoveItem(SessionEnum sessionServiceEnum, string suffix);
        string GetSessionGuid();
    }

    [ExcludeFromCodeCoverage]
    internal class SessionService : ISessionService
    {
        private HttpContextBase _httpContextBase;
        internal HttpContextBase HttpContextBase
        {
            get
            {
                return _httpContextBase ?? new HttpContextWrapper(HttpContext.Current);
            }
            set { _httpContextBase = value; }
        }

        public bool IsAvailable
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    return false;
                return true;
            }
        }

        public bool ItemExists(SessionEnum sessionServiceEnum)
        {
            return ItemExists(sessionServiceEnum, String.Empty);
        }

        public bool ItemExists(SessionEnum sessionServiceEnum, string suffix)
        {
            if (!IsAvailable)
                throw new ApplicationException("HttpContext current or session is not available to check if an item exists in session");

            object obj = HttpContext.Current.Session[string.Format("{0}{1}", sessionServiceEnum, suffix)];
            if (obj == null)
                return false;
            return true;
        }

        public void SetItem<T>(SessionEnum sessionServiceEnum, T objectToSave)
        {
            SetItem(sessionServiceEnum, String.Empty, objectToSave);
        }

        public void SetItem<T>(SessionEnum sessionServiceEnum, string suffix, T objectToSave)
        {
            if (!IsAvailable)
                throw new NullReferenceException("HttpContext.Current.Session is not available");

            HttpContext.Current.Session.Add(string.Format("{0}{1}", sessionServiceEnum, suffix), objectToSave);
        }

        public T GetItem<T>(SessionEnum sessionServiceEnum)
        {
            return GetItem<T>(sessionServiceEnum, String.Empty);
        }

        public T GetItem<T>(SessionEnum sessionServiceEnum, string suffix)
        {
            if (!IsAvailable)
                return default(T);

            object obj = HttpContext.Current.Session[string.Format("{0}{1}", sessionServiceEnum, suffix)];
            if (obj == null)
                return default(T);
            return (T)obj;
        }

        public bool RemoveItem(SessionEnum sessionServiceEnum)
        {
            return RemoveItem(sessionServiceEnum, string.Empty);
        }

        public bool RemoveItem(SessionEnum sessionServiceEnum, string suffix)
        {
            if (ItemExists(sessionServiceEnum, suffix))
            {
                HttpContext.Current.Session.Remove(string.Format("{0}{1}", sessionServiceEnum, suffix));
                return true;
            }
            return false;
        }

        public string GetSessionGuid()
        {
            return HttpContext.Current.Session.SessionID;
        }
    }
}