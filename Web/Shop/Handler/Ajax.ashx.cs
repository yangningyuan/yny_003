using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace yny_003.Web.Shop.Handler
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string result = "非法操作";
            if (!string.IsNullOrEmpty(context.Request["type"]))
                result = Operation(context.Request["type"]);

            context.Response.Write(result);
        }

        private string Operation(string type)
        {
            switch (type)
            {
                case "AddShopCar"://从详细页面加入购物车
                    return AddShopCar();
                case "BatchAddShopCar"://从列表页加入购物车
                    return BatchAddShopCar();
                case "SubmitOrder"://提交订单
                    return SubmitOrder();
                case "sendOrder"://发货
                    return sendOrder();
                case "receiveOrder"://收货
                    return receiveOrder();
                case "seeExpress"://查看订单物流信息
                    return seeExpress();
                case "UpdateShopCar"://修改购物车信息
                    return UpdateShopCar();
                case "Del_ReceiveInfo"://删除收货人信息
                    return DeleteReceiveInfo();
            }
            return "非法操作";
        }

        # region 商城

        private object lockObj = new object();

        public string AddShopCar()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    string gid = _context.Request["pram"];
                    string count = _context.Request["count"];
                    string pop = _context.Request["pop"]; //pop=1，就是立即提交的订单
                    //先查看购物车中有没有该用户的该产品
                    Hashtable hs = new Hashtable();
                    Model.ShopCar car = BLL.ShopCar.GetList("IsDeleted=0 and Status=1 and MID='" + TModel.MID + "' and GId=" + gid).FirstOrDefault();
                    if (car != null)
                    {
                        car.GCount = car.GCount + int.Parse(count);
                        BLL.ShopCar.Update(car, hs);
                    }
                    else
                    {
                        car = new Model.ShopCar();
                        car.AddBy = TModel.MID;
                        car.AddTime = DateTime.Now;
                        car.Code = GetGuid();
                        car.GCount = int.Parse(count);
                        car.GId = int.Parse(gid);
                        car.IsDeleted = false;
                        car.MID = TModel.MID;
                        car.Status = 1;
                        car.BuyPrice = BLL.Goods.GetModel(gid).CostPrice;
                        BLL.ShopCar.Insert(car, hs);
                    }
                    if (!string.IsNullOrEmpty(pop) && pop == "1")
                    {

                    }

                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                return result;
            }
        }

        public string UpdateShopCar()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    string cid = _context.Request["pram"];
                    string count = _context.Request["count"];
                    //先查看购物车中有没有该用户的该产品
                    Hashtable hs = new Hashtable();
                    Model.ShopCar car = BLL.ShopCar.GetModel(cid);
                    if (car != null)
                    {
                        car.GCount = int.Parse(count);
                        BLL.ShopCar.Update(car, hs);
                    }

                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                return result;
            }
        }

        public string BatchAddShopCar()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    string gid = _context.Request["pram"];
                    string count = "1";
                    //先查看购物车中有没有该用户的该产品
                    Hashtable hs = new Hashtable();
                    string[] array = gid.Split(',');
                    foreach (string str in array)
                    {
                        Model.ShopCar car = BLL.ShopCar.GetList("IsDeleted=0 and Status=1  and MID='" + TModel.MID + "' and GId=" + str).FirstOrDefault();
                        if (car != null)
                        {
                            car.GCount = car.GCount + int.Parse(count);
                            BLL.ShopCar.Update(car, hs);
                        }
                        else
                        {
                            car = new Model.ShopCar();
                            car.AddBy = TModel.MID;
                            car.AddTime = DateTime.Now;
                            car.Code = GetGuid();
                            car.GCount = int.Parse(count);
                            car.GId = int.Parse(str);
                            car.IsDeleted = false;
                            car.MID = TModel.MID;
                            car.Status = 1;
                            car.BuyPrice = BLL.Goods.GetModel(str).CostPrice;
                            BLL.ShopCar.Insert(car, hs);
                        }
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "添加成功";
                    else
                        result = "添加失败";
                }
                else
                {
                    result = "添加失败";
                }
                return result;
            }
        }

        public string SubmitOrder()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    string gid = _context.Request["pram"];
                    //string receiveId = _context.Request["otherParm"];
                    Hashtable hs = new Hashtable();
                    string[] array = gid.Split(',');
                    //先生成订单主表
                    Model.Order order = new Model.Order();
                    DateTime dt = DateTime.Now;
                    string code = dt.ToString("yyyyMMddHHmmssfff");// dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
                    order.Code = code;
                    order.ReceiveId =0;
                    order.CreatedBy = TModel.MID;
                    order.CreatedTime = DateTime.Now;
                    //order.GoodCount
                    decimal count = 0; decimal totalMoney = 0;
                    string error = string.Empty;
                    foreach (string str in array)
                    {
                        Model.ShopCar car = BLL.ShopCar.GetModel(str);
                        if (car != null)
                        {
                            Model.OrderDetail od = new Model.OrderDetail();
                            od.BuyPrice = car.BuyPrice;
                            od.Code = GetGuid();
                            od.CreatedBy = TModel.MID;
                            od.CreatedTime = DateTime.Now;
                            od.GCount = car.GCount;
                            count += od.GCount;
                            od.GId = car.GId;
                            //查看库存数量是否足够，不够的话暂时不能提交订单
                            Model.Goods go = BLL.Goods.GetModel(car.GId);
                            if (go.SellingCount < car.GCount)
                            {
                                error += "商品：" + go.GName + "库存不足，请联系管理员";
                            }
							//go.SelledCount = go.SelledCount + od.GCount;//完成订单时候加减库存
							//go.SellingCount = go.SellingCount - od.GCount;
							//BLL.Goods.Update(go, hs);

							od.IsDeleted = false;
                            od.OrderCode = order.Code;
                            od.Status = 1;
                            od.TotalMoney = od.GCount * od.BuyPrice;
                            totalMoney += od.TotalMoney;
                            BLL.OrderDetail.Insert(od, hs);
                            car.Status = 2;
                            BLL.ShopCar.Update(car, hs);
                        }
                    }
                    order.GoodCount = count;
                    order.IsDeleted = false;
                    order.MID = "";
                    order.OrderTime = DateTime.Now;
                    order.Status = 1;
                    order.TotalPrice = totalMoney;
                    order.DisCountTotalPrice = order.TotalPrice;// * BLL.Configuration.Model.E_GWDiscount;
                    BLL.Order.Insert(order, hs);

                    if (!string.IsNullOrEmpty(error))
                    {
                        result = error;
                    }
                    else
                    {
                        if (BLL.CommonBase.RunHashtable(hs))
                            result = "订单生成成功";
                        else
                            result = "订单生成失败";
                    }
                }
                else
                {
                    result = "生成失败";
                }
                return result;
            }
        }

        public string sendOrder()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    string orderid = _context.Request["pram"];
                    string expresscompany = _context.Request["com"];
                    string expresscode = _context.Request["code"];
                    Hashtable hs = new Hashtable();
                    Model.Order order = BLL.Order.GetModel(orderid);
                    if (orderid != null)
                    {
                        order.Status = 3;
                        order.ExpressCode = expresscode;
                        order.ExpressCompany = expresscompany;
                        BLL.Order.Update(order, hs);
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                return result;
            }
        }

        public string receiveOrder()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    string orderid = _context.Request["pram"];
                    Hashtable hs = new Hashtable();
                    Model.Order order = BLL.Order.GetModel(orderid);
                    if (orderid != null)
                    {
                        order.Status = 4;
                        BLL.Order.Update(order, hs);
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                return result;
            }
        }

        public string seeExpress()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    string orderid = _context.Request["pram"];
                    Model.Order order = BLL.Order.GetModel(orderid);
                    if (orderid != null)
                    {
                        result += order.ExpressCode + "≌";
                        result += order.ExpressCompany;
                    }
                }
                else
                {
                    result = "0";
                }
                return result;
            }
        }

        public string DeleteReceiveInfo()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    Hashtable hs = new Hashtable();
                    string orderid = _context.Request["pram"];
                    string[] array = orderid.Split(',');
                    foreach (string str in array)
                    {
                        Model.ReceiveInfo order = BLL.ReceiveInfo.GetModel(str);
                        if (orderid != null)
                        {
                            order.IsDeleted = true;
                            BLL.ReceiveInfo.Update(order, hs);
                        }
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "删除成功";
                    else
                        result = "删除失败";
                }
                else
                {
                    result = "删除失败";
                }
                return result;
            }
        }

        # endregion 商城
    }
}