using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Hangman
{
    internal class Program
    {
       static Random random = new Random();

        static string hangmanTemplate = string.Format(@"              _____________
              |           |
              |           |
                          |
                          |
                          |
                          |
                          |
               ___________|_______");
        static string words = "ability\r\nable\r\nabout\r\nabove\r\naccept\r\naccording\r\naccount\r\nacross\r\nact\r\naction\r\nactivity\r\nactually\r\nadd\r\naddress\r\nadministration\r\nadmit\r\nadult\r\naffect\r\nafter\r\nagain\r\nagainst\r\nage\r\nagency\r\nagent\r\nago\r\nagree\r\nagreement\r\nahead\r\nair\r\nall\r\nallow\r\nalmost\r\nalone\r\nalong\r\nalready\r\nalso\r\nalthough\r\nalways\r\nAmerican\r\namong\r\namount\r\nanalysis\r\nand\r\nanimal\r\nanother\r\nanswer\r\nany\r\nanyone\r\nanything\r\nappear\r\napply\r\napproach\r\narea\r\nargue\r\narm\r\naround\r\narrive\r\nart\r\narticle\r\nartist\r\nas\r\nask\r\nassume\r\nat\r\nattack\r\nattention\r\nattorney\r\naudience\r\nauthor\r\nauthority\r\navailable\r\navoid\r\naway\r\nbaby\r\nback\r\nbad\r\nbag\r\nball\r\nbank\r\nbar\r\nbase\r\nbe\r\nbeat\r\nbeautiful\r\nbecause\r\nbecome\r\nbed\r\nbefore\r\nbegin\r\nbehavior\r\nbehind\r\nbelieve\r\nbenefit\r\nbest\r\nbetter\r\nbetween\r\nbeyond\r\nbig\r\nbill\r\nbillion\r\nbit\r\nblack\r\nblood\r\nblue\r\nboard\r\nbody\r\nbook\r\nborn\r\nboth\r\nbox\r\nboy\r\nbreak\r\nbring\r\nbrother\r\nbudget\r\nbuild\r\nbuilding\r\nbusiness\r\nbut\r\nbuy\r\nby\r\ncall\r\ncamera\r\ncampaign\r\ncan\r\ncancer\r\ncandidate\r\ncapital\r\ncar\r\ncard\r\ncare\r\ncareer\r\ncarry\r\ncase\r\ncatch\r\ncause\r\ncell\r\ncenter\r\ncentral\r\ncentury\r\ncertain\r\ncertainly\r\nchair\r\nchallenge\r\nchance\r\nchange\r\ncharacter\r\ncharge\r\ncheck\r\nchild\r\nchoice\r\nchoose\r\nchurch\r\ncitizen\r\ncity\r\ncivil\r\nclaim\r\nclass\r\nclear\r\nclearly\r\nclose\r\ncoach\r\ncold\r\ncollection\r\ncollege\r\ncolor\r\ncome\r\ncommercial\r\ncommon\r\ncommunity\r\ncompany\r\ncompare\r\ncomputer\r\nconcern\r\ncondition\r\nconference\r\nCongress\r\nconsider\r\nconsumer\r\ncontain\r\ncontinue\r\ncontrol\r\ncost\r\ncould\r\ncountry\r\ncouple\r\ncourse\r\ncourt\r\ncover\r\ncreate\r\ncrime\r\ncultural\r\nculture\r\ncup\r\ncurrent\r\ncustomer\r\ncut\r\ndark\r\ndata\r\ndaughter\r\nday\r\ndead\r\ndeal\r\ndeath\r\ndebate\r\ndecade\r\ndecide\r\ndecision\r\ndeep\r\ndefense\r\ndegree\r\nDemocrat\r\ndemocratic\r\ndescribe\r\ndesign\r\ndespite\r\ndetail\r\ndetermine\r\ndevelop\r\ndevelopment\r\ndie\r\ndifference\r\ndifferent\r\ndifficult\r\ndinner\r\ndirection\r\ndirector\r\ndiscover\r\ndiscuss\r\ndiscussion\r\ndisease\r\ndo\r\ndoctor\r\ndog\r\ndoor\r\ndown\r\ndraw\r\ndream\r\ndrive\r\ndrop\r\ndrug\r\nduring\r\neach\r\nearly\r\neast\r\neasy\r\neat\r\neconomic\r\neconomy\r\nedge\r\neducation\r\neffect\r\neffort\r\neight\r\neither\r\nelection\r\nelse\r\nemployee\r\nend\r\nenergy\r\nenjoy\r\nenough\r\nenter\r\nentire\r\nenvironment\r\nenvironmental\r\nespecially\r\nestablish\r\neven\r\nevening\r\nevent\r\never\r\nevery\r\neverybody\r\neveryone\r\neverything\r\nevidence\r\nexactly\r\nexample\r\nexecutive\r\nexist\r\nexpect\r\nexperience\r\nexpert\r\nexplain\r\neye\r\nface\r\nfact\r\nfactor\r\nfail\r\nfall\r\nfamily\r\nfar\r\nfast\r\nfather\r\nfear\r\nfederal\r\nfeel\r\nfeeling\r\nfew\r\nfield\r\nfight\r\nfigure\r\nfill\r\nfilm\r\nfinal\r\nfinally\r\nfinancial\r\nfind\r\nfine\r\nfinger\r\nfinish\r\nfire\r\nfirm\r\nfirst\r\nfish\r\nfive\r\nfloor\r\nfly\r\nfocus\r\nfollow\r\nfood\r\nfoot\r\nfor\r\nforce\r\nforeign\r\nforget\r\nform\r\nformer\r\nforward\r\nfour\r\nfree\r\nfriend\r\nfrom\r\nfront\r\nfull\r\nfund\r\nfuture\r\ngame\r\ngarden\r\ngas\r\ngeneral\r\ngeneration\r\nget\r\ngirl\r\ngive\r\nglass\r\ngo\r\ngoal\r\ngood\r\ngovernment\r\ngreat\r\ngreen\r\nground\r\ngroup\r\ngrow\r\ngrowth\r\nguess\r\ngun\r\nguy\r\nhair\r\nhalf\r\nhand\r\nhang\r\nhappen\r\nhappy\r\nhard\r\nhave\r\nhe\r\nhead\r\nhealth\r\nhear\r\nheart\r\nheat\r\nheavy\r\nhelp\r\nher\r\nhere\r\nherself\r\nhigh\r\nhim\r\nhimself\r\nhis\r\nhistory\r\nhit\r\nhold\r\nhome\r\nhope\r\nhospital\r\nhot\r\nhotel\r\nhour\r\nhouse\r\nhow\r\nhowever\r\nhuge\r\nhuman\r\nhundred\r\nhusband\r\nidea\r\nidentify\r\nif\r\nimage\r\nimagine\r\nimpact\r\nimportant\r\nimprove\r\nin\r\ninclude\r\nincluding\r\nincrease\r\nindeed\r\nindicate\r\nindividual\r\nindustry\r\ninformation\r\ninside\r\ninstead\r\ninstitution\r\ninterest\r\ninteresting\r\ninternational\r\ninterview\r\ninto\r\ninvestment\r\ninvolve\r\nissue\r\nit\r\nitem\r\nits\r\nitself\r\njob\r\njoin\r\njust\r\nkeep\r\nkey\r\nkid\r\nkill\r\nkind\r\nkitchen\r\nknow\r\nknowledge\r\nland\r\nlanguage\r\nlarge\r\nlast\r\nlate\r\nlater\r\nlaugh\r\nlaw\r\nlawyer\r\nlay\r\nlead\r\nleader\r\nlearn\r\nleast\r\nleave\r\nleft\r\nleg\r\nlegal\r\nless\r\nlet\r\nletter\r\nlevel\r\nlie\r\nlife\r\nlight\r\nlike\r\nlikely\r\nline\r\nlist\r\nlisten\r\nlittle\r\nlive\r\nlocal\r\nlong\r\nlook\r\nlose\r\nloss\r\nlot\r\nlove\r\nlow\r\nmachine\r\nmagazine\r\nmain\r\nmaintain\r\nmajor\r\nmajority\r\nmake\r\nman\r\nmanage\r\nmanagement\r\nmanager\r\nmany\r\nmarket\r\nmarriage\r\nmaterial\r\nmatter\r\nmay\r\nmaybe\r\nme\r\nmean\r\nmeasure\r\nmedia\r\nmedical\r\nmeet\r\nmeeting\r\nmember\r\nmemory\r\nmention\r\nmessage\r\nmethod\r\nmiddle\r\nmight\r\nmilitary\r\nmillion\r\nmind\r\nminute\r\nmiss\r\nmission\r\nmodel\r\nmodern\r\nmoment\r\nmoney\r\nmonth\r\nmore\r\nmorning\r\nmost\r\nmother\r\nmouth\r\nmove\r\nmovement\r\nmovie\r\nMr\r\nMrs\r\nmuch\r\nmusic\r\nmust\r\nmy\r\nmyself\r\nname\r\nnation\r\nnational\r\nnatural\r\nnature\r\nnear\r\nnearly\r\nnecessary\r\nneed\r\nnetwork\r\nnever\r\nnew\r\nnews\r\nnewspaper\r\nnext\r\nnice\r\nnight\r\nno\r\nnone\r\nnor\r\nnorth\r\nnot\r\nnote\r\nnothing\r\nnotice\r\nnow\r\nn't\r\nnumber\r\noccur\r\nof\r\noff\r\noffer\r\noffice\r\nofficer\r\nofficial\r\noften\r\noh\r\noil\r\nok\r\nold\r\non\r\nonce\r\none\r\nonly\r\nonto\r\nopen\r\noperation\r\nopportunity\r\noption\r\nor\r\norder\r\norganization\r\nother\r\nothers\r\nour\r\nout\r\noutside\r\nover\r\nown\r\nowner\r\npage\r\npain\r\npainting\r\npaper\r\nparent\r\npart\r\nparticipant\r\nparticular\r\nparticularly\r\npartner\r\nparty\r\npass\r\npast\r\npatient\r\npattern\r\npay\r\npeace\r\npeople\r\nper\r\nperform\r\nperformance\r\nperhaps\r\nperiod\r\nperson\r\npersonal\r\nphone\r\nphysical\r\npick\r\npicture\r\npiece\r\nplace\r\nplan\r\nplant\r\nplay\r\nplayer\r\nPM\r\npoint\r\npolice\r\npolicy\r\npolitical\r\npolitics\r\npoor\r\npopular\r\npopulation\r\nposition\r\npositive\r\npossible\r\npower\r\npractice\r\nprepare\r\npresent\r\npresident\r\npressure\r\npretty\r\nprevent\r\nprice\r\nprivate\r\nprobably\r\nproblem\r\nprocess\r\nproduce\r\nproduct\r\nproduction\r\nprofessional\r\nprofessor\r\nprogram\r\nproject\r\nproperty\r\nprotect\r\nprove\r\nprovide\r\npublic\r\npull\r\npurpose\r\npush\r\nput\r\nquality\r\nquestion\r\nquickly\r\nquite\r\nrace\r\nradio\r\nraise\r\nrange\r\nrate\r\nrather\r\nreach\r\nread\r\nready\r\nreal\r\nreality\r\nrealize\r\nreally\r\nreason\r\nreceive\r\nrecent\r\nrecently\r\nrecognize\r\nrecord\r\nred\r\nreduce\r\nreflect\r\nregion\r\nrelate\r\nrelationship\r\nreligious\r\nremain\r\nremember\r\nremove\r\nreport\r\nrepresent\r\nRepublican\r\nrequire\r\nresearch\r\nresource\r\nrespond\r\nresponse\r\nresponsibility\r\nrest\r\nresult\r\nreturn\r\nreveal\r\nrich\r\nright\r\nrise\r\nrisk\r\nroad\r\nrock\r\nrole\r\nroom\r\nrule\r\nrun\r\nsafe\r\nsame\r\nsave\r\nsay\r\nscene\r\nschool\r\nscience\r\nscientist\r\nscore\r\nsea\r\nseason\r\nseat\r\nsecond\r\nsection\r\nsecurity\r\nsee\r\nseek\r\nseem\r\nsell\r\nsend\r\nsenior\r\nsense\r\nseries\r\nserious\r\nserve\r\nservice\r\nset\r\nseven\r\nseveral\r\nsex\r\nsexual\r\nshake\r\nshare\r\nshe\r\nshoot\r\nshort\r\nshot\r\nshould\r\nshoulder\r\nshow\r\nside\r\nsign\r\nsignificant\r\nsimilar\r\nsimple\r\nsimply\r\nsince\r\nsing\r\nsingle\r\nsister\r\nsit\r\nsite\r\nsituation\r\nsix\r\nsize\r\nskill\r\nskin\r\nsmall\r\nsmile\r\nso\r\nsocial\r\nsociety\r\nsoldier\r\nsome\r\nsomebody\r\nsomeone\r\nsomething\r\nsometimes\r\nson\r\nsong\r\nsoon\r\nsort\r\nsound\r\nsource\r\nsouth\r\nsouthern\r\nspace\r\nspeak\r\nspecial\r\nspecific\r\nspeech\r\nspend\r\nsport\r\nspring\r\nstaff\r\nstage\r\nstand\r\nstandard\r\nstar\r\nstart\r\nstate\r\nstatement\r\nstation\r\nstay\r\nstep\r\nstill\r\nstock\r\nstop\r\nstore\r\nstory\r\nstrategy\r\nstreet\r\nstrong\r\nstructure\r\nstudent\r\nstudy\r\nstuff\r\nstyle\r\nsubject\r\nsuccess\r\nsuccessful\r\nsuch\r\nsuddenly\r\nsuffer\r\nsuggest\r\nsummer\r\nsupport\r\nsure\r\nsurface\r\nsystem\r\ntable\r\ntake\r\ntalk\r\ntask\r\ntax\r\nteach\r\nteacher\r\nteam\r\ntechnology\r\ntelevision\r\ntell\r\nten\r\ntend\r\nterm\r\ntest\r\nthan\r\nthank\r\nthat\r\nthe\r\ntheir\r\nthem\r\nthemselves\r\nthen\r\ntheory\r\nthere\r\nthese\r\nthey\r\nthing\r\nthink\r\nthird\r\nthis\r\nthose\r\nthough\r\nthought\r\nthousand\r\nthreat\r\nthree\r\nthrough\r\nthroughout\r\nthrow\r\nthus\r\ntime\r\nto\r\ntoday\r\ntogether\r\ntonight\r\ntoo\r\ntop\r\ntotal\r\ntough\r\ntoward\r\ntown\r\ntrade\r\ntraditional\r\ntraining\r\ntravel\r\ntreat\r\ntreatment\r\ntree\r\ntrial\r\ntrip\r\ntrouble\r\ntrue\r\ntruth\r\ntry\r\nturn\r\nTV\r\ntwo\r\ntype\r\nunder\r\nunderstand\r\nunit\r\nuntil\r\nup\r\nupon\r\nus\r\nuse\r\nusually\r\nvalue\r\nvarious\r\nvery\r\nvictim\r\nview\r\nviolence\r\nvisit\r\nvoice\r\nvote\r\nwait\r\nwalk\r\nwall\r\nwant\r\nwar\r\nwatch\r\nwater\r\nway\r\nwe\r\nweapon\r\nwear\r\nweek\r\nweight\r\nwell\r\nwest\r\nwestern\r\nwhat\r\nwhatever\r\nwhen\r\nwhere\r\nwhether\r\nwhich\r\nwhile\r\nwhite\r\nwho\r\nwhole\r\nwhom\r\nwhose\r\nwhy\r\nwide\r\nwife\r\nwill\r\nwin\r\nwind\r\nwindow\r\nwish\r\nwith\r\nwithin\r\nwithout\r\nwoman\r\nwonder\r\nword\r\nwork\r\nworker\r\nworld\r\nworry\r\nwould\r\nwrite\r\nwriter\r\nwrong\r\nyard\r\nyeah\r\nyear\r\nyes\r\nyet\r\nyou\r\nyoung\r\nyour\r\nyourself";
        static string[] wordsSeperated = words.Split("\r" + "\n");
        static int index = random.Next(0, wordsSeperated.Length);
        static string keyWord = wordsSeperated[index];
        //static string keyWord = "elephant";
        
        static string underscores = "";
        static char guess;
        static int guessedIncorrectly = 0;
        static List<char> guessedLetters = new List<char>();
        static List<char> guessedIncorrectList = new List<char>();

        static void Main(string[] args)
        {

            // set undersocres
            foreach (char c in keyWord)
            {
                underscores = underscores + "_";
            }

            // Display the results
            Hangman();

            
            // loop through each character to check is equal
            while (guessedIncorrectly < 6 && underscores.Contains("_"))
            {
                int guessedCorrectly = 0;
                // get the character guessed
                CHarVerification();

                // goes through each character to check if guess is equal to the letter in the word
                for (int i = 0; i < keyWord.Length; i++)
                {

                    if (keyWord[i] == guess)
                    {
                        underscores = RemoveChar(underscores, i);
                        underscores = underscores.Insert(i, guess.ToString());
                        guessedCorrectly++;
                        guessedLetters.Add(guess);
                        Hangman();
                    }
                    else if (guessedCorrectly == 0 && i == keyWord.Length - 1)
                    {
                        guessedIncorrectly++;
                        guessedLetters.Add(guess);
                        guessedIncorrectList.Add(guess);
                        HangmanAddBodyParts();
                    }

                }
            }

            if (guessedIncorrectly < 6)
                Console.WriteLine("\n\n\t\t    YOU WIN!");
            else if (underscores.Contains("_"))
            {
                Console.WriteLine("\n\n\t\t    YOU LOSE!");
                Console.WriteLine($"\nTHe word was {keyWord}");
            }



            Console.ReadLine();
        }

        public static void Hangman()
        {
            Console.Clear();

            Console.Write(hangmanTemplate + "\t");

            foreach (char c in underscores)
            {
                Console.Write(c + " ");
            }
            ListOfUsedChars();

        }
        
        public static void HangmanAddBodyParts()
        {
            Console.Clear();

            switch (guessedIncorrectly)
            {
                case 1:
                    hangmanTemplate = string.Format(@"              _____________
              |           |
              |           |
              O           |
                          |
                          |
                          |
                          |
               ___________|_______");
                    Console.Write(hangmanTemplate + "\t");
                    break;
                case 2:
                    hangmanTemplate = string.Format(@"              _____________
              |           |
              |           |
              O           |
              |           |
                          |
                          |
                          |
               ___________|_______");
                    Console.Write(hangmanTemplate + "\t");
                    break;
                case 3:
                    hangmanTemplate = string.Format(@"              _____________
              |           |
              |           |
              O           |
             \|           |
                          |
                          |
                          |
               ___________|_______");
                    Console.Write(hangmanTemplate + "\t");
                    break;
                case 4:
                    hangmanTemplate = string.Format(@"              _____________
              |           |
              |           |
              O           |
             \|/          |
                          |
                          |
                          |
               ___________|_______");
                    Console.Write(hangmanTemplate + "\t");
                    break;
                case 5:
                    hangmanTemplate = string.Format(@"              _____________
              |           |
              |           |
              O           |
             \|/          |
             /            |
                          |
                          |
               ___________|_______");
                    Console.Write(hangmanTemplate + "\t");
                    break;
                case 6:
                    hangmanTemplate = string.Format(@"              _____________
              |           |
              |           |
              O           |
             \|/          |
             / \          |
                          |
                          |
               ___________|_______");
                    Console.Write(hangmanTemplate + "\t");
                    break;

            }


            foreach (char c in underscores)
            {
                Console.Write(c + " ");
            }
            ListOfUsedChars();
        }

        public static char CHarVerification()
        {

            Console.Write("\n\nEnter a letter: ");
            bool check = char.TryParse(Console.ReadLine(), out guess);

            while (!check || !Char.IsLetter(guess))
            {
                Console.Write("Enter a valid character: ");
                check = char.TryParse(Console.ReadLine(), out guess);
            }

            guess = Char.ToLower(guess);

            //check if letter has already been guessed
            for (int i = 0; i < guessedLetters.Count; i++)
            {
                while (guessedLetters[i] == guess)
                {
                    Console.WriteLine("Letter already guessed! ");
                    Console.Write("Enter a different letter: ");
                    check = char.TryParse(Console.ReadLine(), out guess);

                    while (!check || !Char.IsLetter(guess))
                    {
                        Console.Write("Enter a valid character: ");
                        check = char.TryParse(Console.ReadLine(), out guess);
                        
                    }
                    i = 0;
                }

            }

            guess = Char.ToLower(guess);
            return guess;
        }

        public static string RemoveChar(string str, int i)
        {
            return str.Remove(i, 1);
        }

        public static void ListOfUsedChars()
        {
            Console.Write("\tIncorrect guesses: ");
            for (int i = 0; i < guessedIncorrectList.Count; i++)
            {
                Console.Write(" " + guessedIncorrectList[i]);
            }
        }

    }
}
