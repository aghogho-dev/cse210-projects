using Foundation1.Assets;

class Program
{
    static void Main(string[] args)
    {
        string authorOne = "Mark";
        string authorTwo = "Jane";
        string authorThree = "Philip";
        string authorFour = "Dora";

        string titleOne = "Java Programming Tutorial";
        string titleTwo = "C# Programming Tutorial";
        string titleThree = "Python Programming Tutorial";
        string titleFour = "JavaScript Programming Tutorial";

        int lengthOne = 1000;
        int lengthTwo = 1400;
        int lengthThree = 1600;
        int lengthFour = 2000;

        Video videoOne = new Video();
        Video videoTwo = new Video();
        Video videoThree = new Video();
        Video videoFour = new Video();

        videoOne.SetAuthor(authorOne);
        videoOne.SetTitle(titleOne);
        videoOne.SetLength(lengthOne);


        videoTwo.SetAuthor(authorTwo);
        videoTwo.SetTitle(titleTwo);
        videoTwo.SetLength(lengthTwo);

        videoThree.SetAuthor(authorThree);
        videoThree.SetTitle(titleThree);
        videoThree.SetLength(lengthThree);

        videoFour.SetAuthor(authorFour);
        videoFour.SetTitle(titleFour);
        videoFour.SetLength(lengthFour);

        string[] textOne = ["Great Tutorial", "Enjoyed it a lot", "Explained nicely", "It was really helpful"];
        string [] namesOne = ["Joe", "Joseph", "Dan", "Ben"];

        string[] textTwo = ["Great Teacher", "Watched at 2x speed", "Better than my professor", "Where was this channel while I was in college"];
        string [] namesTwo = ["Xi", "Will", "Dong", "Benedict"];

        string[] textThree = ["Well explained", "Enjoyed it a lot", "Too good", "Thank you!"];
        string [] namesThree = ["Janet", "Jack", "Rice", "Havertz"];

        string[] textFour = ["Very helpful", "Enjoyed it", "Explained nicely", "I now understand it"];
        string [] namesFour = ["Dan", "Jack", "Dong", "Ben"];

        for (int i = 0; i < textOne.Length; i++)
        {
            Comment commentOne = new Comment();
            commentOne.SetName(namesOne[i]);
            commentOne.SetText(textOne[i]);
            videoOne.SetComment(commentOne);
        }

        for (int i = 0; i < textTwo.Length; i++)
        {
            Comment commentTwo = new Comment();
            commentTwo.SetName(namesTwo[i]);
            commentTwo.SetText(textTwo[i]);
            videoTwo.SetComment(commentTwo);
        }

        for (int i = 0; i < textThree.Length; i++)
        {
            Comment commentThree = new Comment();
            commentThree.SetName(namesThree[i]);
            commentThree.SetText(textThree[i]);
            videoThree.SetComment(commentThree);
        }

        for (int i = 0; i < textFour.Length; i++)
        {
            Comment commentFour = new Comment();
            commentFour.SetName(namesFour[i]);
            commentFour.SetText(textFour[i]);
            videoFour.SetComment(commentFour);
        }

        List<Video> videos = new List<Video>(){ videoOne, videoTwo, videoThree, videoFour};

        foreach (Video video in videos) {
            video.DisplayVideoInfo();
            video.DisplayComments();
            Console.WriteLine();
        }    
    }
}