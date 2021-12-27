using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIO
{
   public class EncodeTelex
    {
        static string[] ecd = { "w=ww","á=as", "ó=os", "ú=us", "é=es", "à=af", "ò=of", "ù=uf", "è=ef", "ả=ar", "ỏ=or", "ủ=ur", "ẹ=ej", "ạ=aj", "ọ=oj", "ụ=uj", "ẻ=er", "ã=ax", "õ=ox", "ũ=ux", "ẽ=ex", "â=aa", "ô=oo", "ư=uw", "ê=ee", "ă=aw", "ơ=ow", "ứ=uws", "ể=eer", "ấ=aas", "ố=oos", "ừ=uwf", "ễ=eex", "ầ=aaf", "ồ=oof", "ử=uwr", "ế=ees", "ậ=aaj", "ộ=ooj", "ữ=uwx", "ề=eef", "ẩ=aar", "ổ=oor", "ự=uwj", "ệ=eej", "ẫ=aax", "ỗ=oox", "đ=dd", "ý=ys", "ắ=aws", "ớ=ows", "í=is", "ỳ=yf", "ằ=awf", "ờ=owf", "ì=if", "ỷ=yr", "ặ=awj", "ợ=owj", "ị=ij", "ỹ=yx", "ẳ=awr", "ở=owr", "ỉ=ir", "ỵ=yj", "ẵ=awx", "ỡ=owx", "ĩ=ix" };
        public static string ToTelex(string text)
        {
            string kq = text;
            foreach(var item in ecd)
            {
                var nvl = item.Split('=');
                if(nvl[0].ToString() == text)
                {
                    kq = nvl[1].ToString();
                    return kq;
                }
            }
           return kq;
        }
    }
}
