namespace DotNetCoreSampleApp{

    public interface Igreet
    {
       string GreetingOfTheDay();
    }

    public class Greetings : Igreet
    {
        public Greetings()
        {
            GreetingOfTheDay();
        }
        public string GreetingOfTheDay()
        {
            return "Greeting of today : Today is good !!";
        }
    }
}