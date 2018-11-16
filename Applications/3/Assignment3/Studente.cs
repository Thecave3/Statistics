using System;
namespace Assignment3
{

    //  Sesso,Age,Weight (kg),Height (cm),Background,Hobby,Main Interest,Trasportation,Main Informatic Interest
    public class Studente
    {

        public string sex;
        public string age;
        public string weight;
        public string height;
        public string background;
        public string hobby;
        public string interest;
        public string transport;
        public string informatic;

        public Studente(string sex, string age, string weight, string height, string background, string hobby, string interest, string transport, string informatic)
        {
            this.sex = sex;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.background = background;
            this.hobby = hobby;
            this.interest = interest;
            this.transport = transport;
            this.informatic = informatic;
        }

        public override string ToString()
        {
            return this.age + " " + this.weight + " " + this.height + " " + this.background + " " + this.hobby + " " + this.interest + " " + this.transport + " " + this.informatic + " ";
        }

    }
}
