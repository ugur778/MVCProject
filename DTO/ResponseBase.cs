using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DTO
{
    [Serializable]
    public enum ServiceResponseStatuses
    {
        Success,
        Error,
        Warning
    }

    [Serializable]
    [DataContract(Name = "{0}")]
    public class ResponseBase<T>
    {
        #region | Ctor |

        public ResponseBase()
        {
            this.Status = ServiceResponseStatuses.Success;
            Messages = new Dictionary<string, string>();
        }

        #endregion

        #region  | Properties |

        /// <summary>
        /// Sonuç statüsü
        /// </summary>
        [DataMember]
        public ServiceResponseStatuses Status { get; set; }

        /// <summary>
        /// Dönen data
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        /// <summary>
        /// Serviste client a dönen mesaj listesi
        /// </summary>
        [DataMember]
        public Dictionary<string, string> Messages { get; set; }

        #endregion

        #region HelperMethods
        public static ResponseBase<T> CreateResponse(T data)
        {
            var response = new ResponseBase<T> { Status = ServiceResponseStatuses.Success, Data = data };
            return response;
        }

        /// <summary>
        /// Mesaj ekleme
        /// </summary>
        /// <param name="messageKey"></param>
        /// <param name="message"></param>
        public void AddMessage(string messageKey, string message)
        {
            if (this.Messages == null)
            {
                this.Messages = new Dictionary<string, string>();
            }

            bool alreadyExists = this.Messages
                .Where(eachMessage => string.Compare(eachMessage.Key, messageKey, true) == 0)
                .Count() > 0;

            if (!alreadyExists)
            {
                this.Messages.Add(messageKey, message);
            }
        }

        public bool IsSuccessful()
        {
            return this != null && this.Status == ServiceResponseStatuses.Success;
        }
        #endregion

        #region | Error |

        /// <summary>
        /// Mesaj göndermeden hatalı statüsüne çeker
        /// </summary>
        public void Error()
        {
            this.Status = ServiceResponseStatuses.Error;
        }

        /// <summary>
        /// Mesaj ve hata kodu ile hatalı statü çeker
        /// </summary>
        /// <param name="messageKey"></param>
        /// <param name="message"></param>
        public void Error(string messageKey, string message)
        {
            this.Error();
            this.AddMessage(messageKey, message);
        }

        /// <summary>
        /// Exception ile mesaj ve hata kodu dönüşü yapar
        /// </summary>
        /// <param name="ex"></param>
        public void Error(Exception ex)
        {
            this.Error();
            this.AddMessage("", ex.Message);
        }
        /// <summary>
        /// Mesaj ve hata kodu ile hatalı statü çeker
        /// </summary>
        public void Error(Dictionary<string, string> messages)
        {
            this.Error();
            foreach (KeyValuePair<string, string> keyValuePair in messages)
            {
                this.AddMessage(keyValuePair.Key, keyValuePair.Value);
            }
        }

        #endregion

        #region | Success |

        /// <summary>
        /// Baraşılı işlem
        /// </summary>
        public void Success()
        {
            this.Status = ServiceResponseStatuses.Success;
        }

        /// <summary>
        /// Başarılı işlem data set edilyor
        /// </summary>
        /// <param name="data"></param>
        public void Success(T data)
        {
            this.Data = data;
            this.Success();
        }

        /// <summary>
        /// Başarılı işlem data set edilyor ve hata mesajları siliniyor
        /// </summary>
        /// <param name="data"></param>
        public void Success(T data, bool clearMessages)
        {
            this.Data = data;
            if (clearMessages)
            {
                this.Messages.Clear();
            }
            this.Success();
        }

        #endregion

        #region | Warning |

        /// <summary>
        /// Yapılan işlemler setinde bazılarında hata alıp bazılarında hatasız gerçekleşiyorsa,
        ///  bu servisin işleyişinde hata oluşturmuyorsa bu statüye çekili
        /// </summary>
        public void Warning()
        {
            this.Status = ServiceResponseStatuses.Warning;
        }
        /// <summary>
        /// Uyarı mesajları
        /// </summary>
        /// <param name="data"></param>
        /// <param name="messageList"></param>
        public void Warning(T data, Dictionary<string, string> messageList)
        {
            this.Data = data;
            this.Messages = messageList;
            this.Warning();
        }

        /// <summary>
        /// Uyarı mesajları (Liste)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="messageKey"></param>
        /// <param name="message"></param>
        public void Warning(T data, string messageKey, string message)
        {
            this.Data = data;
            this.AddMessage(messageKey, message);
            this.Warning();
        }

        #endregion

    }
}
