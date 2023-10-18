using System;
public class Trapezoid
{
    protected double a;
    protected double b;
    protected double c;
    protected double d;
    public Trapezoid() { }
    public Trapezoid(double a, double b, double c, double d)
    {
        this.a = a; this.b = b; this.c = c; this.d = d;
    }
    //наслідуючий метод
    public void Print()
    {
        Console.WriteLine("a={0} b={1} c={2} d={3}", a, b, c, d);
    }
    //наслідуючий метод
    public double Perimeter()
    {
        double p =a+b+c+d; return p;
    }
    //цей метод віртуальний
    //він перевизначається в дочірньому класі
    virtual public double Sqr()
    {
        Console.WriteLine("Обчислюємо для звичайної");
        double x = ((b - a) * (b - a) + c * c - d * d) / (2 * (b - a));
        double x2 =Math.Pow(x, 2);
        double s = (a + b) * Math.Sqrt(c * c - x2) / 2;
        return s;
    }
}
public class Isoscelesl : Trapezoid
{
    public Isoscelesl() { }
    public Isoscelesl(double a,double b, double c)
    {
        this.a = a; this.b = b;this.c = c; this.d = c;
    }
    //перевизначаємий метод обчислення площі
    public override double Sqr()
    {
        Console.WriteLine("Обчислюємо для рiвнобедренної");
        double s = (a + b) * Math.Sqrt(c * c - (a - b) * (a - b) / 4) / 2;
        return s;
    }
    //власний метод обчислення радіуса вписаного кола
    public double Radius()
    {
        double r = Math.Sqrt(a * b) / 2;
        return r;
    }
}
class Program
{
    static void Main(string[] args)
    {
        double p, s, r = 0;
        int a, b, c, d;
        a = 10;b = 15;c = 7;d = 11;
        //описуємо змінну батьківського класу
        Trapezoid t;
        //рівностороння трапеція
        if (c == d)
        {
            //привласнюємо цій змінній об'єкт дочірнього класу
            t = new Isoscelesl(a, b, c);
            //цей об'єкт потрібен, щоб вікликати власний
            //метод Radius з дочірнього класу
            Isoscelesl t1=new Isoscelesl(a,b,c);
            r=t1.Radius();
        }
        else
        //звичайна трапеція
        {
            //привласнюємо цій змінній об'єкт батьківського класу
            t = new Trapezoid(a, b, c, d);
        }
        //ці методи завжди викликаються з батьківського класу
        t.Print(); p = t.Perimeter();
        //метод Sqr() буде викликатись з того класу,
        //до якого належить об'єкт t
        s = t.Sqr();
        Console.WriteLine("P={0} S={1:F2}", p,s);
        if (c==d) Console.WriteLine("R={0:F2}", r);
        Console.ReadKey();
    }
}