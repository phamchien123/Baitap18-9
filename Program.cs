using System;
using System.Collections.Generic;

class Product
{
    public string Tensp { get; set; }
    public double Gia { get; set; }
    public string Mota { get; set; }
    public int Soluong { get; set; }

    public virtual void Hienthiinfor()
    {
        Console.WriteLine("Tenn san pham: " + Tensp);
        Console.WriteLine("Gia: " + Gia);
        Console.WriteLine("Mo ta: " + Mota);
        Console.WriteLine("So luong: " + Soluong);
    }
}

class Dientu : Product
{
    public int Sothangbh { get; set; }

    public override void Hienthiinfor()
    {
        base.Hienthiinfor();
        Console.WriteLine("So thang bao hanh: " + Sothangbh);
    }
}

class Quanao : Product
{
    public string Mausac { get; set; }
    public string Kichthuoc { get; set; }

    public override void Hienthiinfor()
    {
        base.Hienthiinfor();
        Console.WriteLine("Mau sac: " + Mausac);
        Console.WriteLine("Kich thuoc: " + Kichthuoc);
    }
}

class Thucpham : Product
{
    public string Ngayhethan { get; set; }

    public override void Hienthiinfor()
    {
        base.Hienthiinfor();
        Console.WriteLine("Ngay het han: " + Ngayhethan);
    }
}


class ShoppingCart
{
    private List<Product> Dssanpham = new List<Product>();

    public void Themsp(Product product)
    {
        Dssanpham.Add(product);
        Console.WriteLine("Da them san pham: " + product.Tensp);
    }

    public void Xoasp(Product product)
    {
        if (Dssanpham.Contains(product))
        {
            Dssanpham.Remove(product);
            Console.WriteLine("Da xoa san pham: " + product.Tensp);
        }
        else
        {
            Console.WriteLine("San pham khong co trong gio hang !");
        }
    }

    public void HienthiGiohang()
    {
        Console.WriteLine("\nCac san pham trong gio hang:");
        foreach (var product in Dssanpham)
        {
            product.Hienthiinfor();
            Console.WriteLine();
        }
    }

    public double Tonggiatri()
    {
        double tongtien = 0;
        foreach (var product in Dssanpham)
        {
            tongtien += product.Gia * product.Soluong;
        }
        return tongtien;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Dientu laptop = new Dientu { Tensp = "Laptop", Gia = 1500, Mota = "Laptop choi game", Soluong = 1, Sothangbh = 12 };
        Quanao aoThun = new Quanao { Tensp = "Ao thun", Gia = 20, Mota = "Ao thun cotton", Soluong = 3, Mausac = "Den", Kichthuoc = "M" };
        Thucpham banhMi = new Thucpham { Tensp = "Banh mi", Gia = 5, Mota = "Banh mi goi", Soluong = 2, Ngayhethan = "20/09/2024" };
        ShoppingCart cart = new ShoppingCart();

      
        cart.Themsp(laptop);
        cart.Themsp(aoThun);
        cart.Themsp(banhMi);

       
        cart.HienthiGiohang();

  
        double tongGiaTri = cart.Tonggiatri();
        Console.WriteLine("Tong gia tri don hang: " + tongGiaTri + " USD");

       
        cart.Xoasp(aoThun);

    
        cart.HienthiGiohang();

    
        tongGiaTri = cart.Tonggiatri();
        Console.WriteLine("Tong gia tri don hang sau khi xoa: " + tongGiaTri + " USD");
    }
}
