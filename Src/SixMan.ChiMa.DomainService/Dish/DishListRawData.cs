using SixMan.ChiMa.Domain.Extensions;
using SixMan.UICommon.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class DishListRawData
        : List<DishDetailsRawData>
    {
        public DishListRawData() { }

        public DishListRawData(List<DishDetailsRawData> dishDetails)
        {
            this.AddRange(dishDetails);
        }

        public IEnumerable<DishImgItem> GetImgs()
        {
            foreach (var dc in this)
            {
                foreach (var d in dc)
                {
                    if (d.SmallImageUrl.IsNotNullOrEmpty())
                    {
                        yield return new DishImgItem()
                        {
                            SourcrUrl = d.SmallImageUrl,
                            LocalPath = d.SmallImageLocalPath(),
                        };
                    }
                    if (d.BigImageUrl.IsNotNullOrEmpty())
                    {
                        yield return new DishImgItem()
                        {
                            SourcrUrl = d.BigImageUrl,
                            LocalPath = d.BigImageLocalPath(),
                        };
                    }
                    if (d.Cookery != null)
                    {
                        int stepNo = 1;
                        foreach (var c in d.Cookery)
                        {
                            if (c.Photo.IsNotNullOrEmpty())
                            {
                                yield return new DishImgItem()
                                {
                                    SourcrUrl = c.Photo,
                                    LocalPath = d.CookeryLocalPath(stepNo++),
                                };
                            }
                        }
                    }
                }
            }
        }

        internal IEnumerable<DishDetailsRawDataItem> GetDishs()
        {
            foreach(var dishs in this)
            {
                foreach( var dish in dishs)
                {
                    yield return dish;
                }
            }
        }
    }

    //public class DishListRawDataItem
    //    : List<DishDetailsRawDataItem>
    //{        
    //    public string Tag { get; set; }        
    //}
}
