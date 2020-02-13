using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Builder_Pattern
{
    /// <summary>
    /// 建造模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 何时使用：一些基本部件不会变，而其组合经常变化的时候。
            // 其中ZuoZhu就是类似一个组合器
            ZuoZhu person = new ZuoZhu();
            person.Wear(new HandArmour());
            person.Wear(new Helmet());
            person.Wear(new Helmet());
            var result = person.ShowAttribute();
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }

    #region 装备
    /// <summary>
    /// 装备
    /// </summary>
    public abstract class Equipment
    {
        public abstract string Name { get; }
        public Attribute Attr { get; protected set; }
        public int AttrVal { get; protected set; }
        public void SetAttr(Attribute key, int value)
        {
            Attr = key;
            AttrVal = value;
        }
    }
    /// <summary>
    /// 手甲
    /// </summary>
    public class HandArmour : Equipment
    {
        public HandArmour()
        {
            SetAttr(Attribute.AGI, 10);
        }
        public override string Name => "手甲";
    }
    public class Helmet : Equipment
    {
        public Helmet()
        {
            SetAttr(Attribute.VIT, 20);
        }

        public override string Name => "头盔";
    }
    #endregion
    public class ZuoZhu : AbstractPerson
    {
        public override string UserName => "二柱子";
    }

    /// <summary>
    /// 抽象人
    /// </summary>
    public abstract class AbstractPerson
    {
        private readonly IDictionary<string, Equipment> dicEqus = new Dictionary<string, Equipment>();

        /// <summary>
        /// 穿戴装备，装备一样会覆盖，
        /// </summary>
        /// <param name="equipment"></param>
        public virtual void Wear(Equipment equipment)
        {
            if (equipment == null) return;
            if (dicEqus.ContainsKey(equipment.Name))
                dicEqus[equipment.Name] = equipment;
            else
                dicEqus.Add(equipment.Name, equipment);
        }
        public abstract string UserName { get; }
        public string ShowAttribute()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UserName + " 全部属性如下\r\n");
            foreach (var item in dicEqus)
            {
                var val = item.Value;
                sb.AppendFormat("  {0} : {1} +{2}\r\n", val.Name, val.Attr.ToString(), val.AttrVal);
            }
            return sb.ToString();
        }
    }
    /// <summary>
    /// 属性值
    /// </summary>
    public enum Attribute
    {
        VIT,// 耐力 （防御力）
        AGI,// 敏捷 （回避/攻速）
        DEX,// 灵巧 （命中）
        DROP,//  掉宝率
        CRT,// 爆击率
    }
}
