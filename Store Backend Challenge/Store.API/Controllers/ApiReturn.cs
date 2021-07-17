using System.Collections;
using System.Collections.Generic;

namespace Store_Backend_Challenge.Controllers
{

    public class ApiReturn<T> : ApiReturn
    {
        public T Data { get; set; }
    }

    public class ApiReturn
    {
        public ApiStatusCode Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public ApiErrorCollection Errors { get; set; }
        public object ReturnedData { get; set; }
    }

    public class ApiError
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public ApiStatusCode Code { get; set; }
        public string InternalMessage { get; set; }
    }

    public class ApiErrorCollection : ICollection<ApiError>
    {
        private readonly List<ApiError> _data;

        public ApiErrorCollection()
        {
            _data = new List<ApiError>();
        }

        public IEnumerator<ApiError> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public void Add(string message)
        {
            Add(string.Empty, message);
        }

        public void Add(string key, string message, string internalErrorMessage = default(string), ApiStatusCode code = 0)
        {
            Add(new ApiError
            {
                Code = code,
                InternalMessage = internalErrorMessage,
                Key = key,
                Message = message
            });
        }

        public void Add(ApiError item)
        {
            _data.Add(item);
        }

        public void AddRange(IEnumerable<ApiError> items)
        {
            _data.AddRange(items);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(ApiError item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(ApiError[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public bool Remove(ApiError item)
        {
            return _data.Remove(item);
        }

        public int Count => _data.Count;
        public bool IsReadOnly => false;
    }
}
