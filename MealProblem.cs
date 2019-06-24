using System;
   public class MealProblem
    {
    // coll is an array for use in tie cases.
    public static int[] coll = null;
    // exceptional_case_item is used for the case when in all parameter tie occur
    public static int exceptional_case_item = -1;

    // This method is just choosing the maximum content value item when CAPITAL alphabet given as 'T' or anyother
    public static int ChooseMax(int[] participent_element)
       {
           try{
        int count=0;
        int max = -1;
         for(int i=0;i<coll.Length;i++)
          if(coll[i]==0)
           {
              max = i;
              break; 
           }
        for(int i=1;i<participent_element.Length;i++)
         {
          if(participent_element[i]>participent_element[max]&&coll[i]==0)
           {
             max = i;
           }
         }
         for(int i=0;i<participent_element.Length;i++)
         {
          if(participent_element[i]==participent_element[max])
            count++;
          else 
            coll[i] = 1;
         }
        if(count==1)
         return max;
        exceptional_case_item = max;
           }
           catch(Exception e)
            {
             Console.WriteLine(e);
            }
            return -1;
       }

// This method is just choosing the minimum content value item when SMALL alphabet given as 't' or anyother
       public static int ChooseMin(int[] participent_element)
       {
        try{
        int count=0;
        int min = -1;
        for(int i=0;i<coll.Length;i++)
          if(coll[i]==0)
           {
              min = i;
              break; 
           }
        for(int i=1;i<participent_element.Length;i++)
         {
          if(participent_element[i]<participent_element[min]&&coll[i]==0)
           {
             min = i;
           }
         }
         for(int i=0;i<participent_element.Length;i++)
          {if(participent_element[i]==participent_element[min])
            count++;
            else
            coll[i] = 1;
          }
        if(count==1)
         return min;
        exceptional_case_item = min;
        
        }
        catch(Exception e)
         {
            Console.WriteLine(e);
         }
         return -1;
       }

       // This is the prime calculation method
      static public int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
       {
          
         int e=0;
         int n = protein.Length;
         int[] output = new int[dietPlans.Length];
         for(int i=0;i<output.Length;i++)
          {
            output[i] = -1;
          }
         int[] cal = new int[n];
         for(int i=0;i<n;i++)
          {
           cal[i] = (protein[i]+carbs[i])*5+fat[i]*9;
          }
          char[] diet_prescribed = new char[4];
          int m =0;
          try{
          for(int i=0;i<dietPlans.Length;i++)
           {
             diet_prescribed = dietPlans[i].ToCharArray();
             m = diet_prescribed.Length;
             for(int j=0;j<m;j++)
             {
               switch(diet_prescribed[j])
               {
                 
                 case 'f':
                 output[i] = ChooseMin(fat);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;
                  
                  case 'F':
                     output[i] = ChooseMax(fat);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;        

                   case 'c':
                    output[i] = ChooseMin(carbs);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;

                   case 'C':
                    output[i] = ChooseMax(carbs);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;  

                   case 'T':
                    output[i] = ChooseMax(cal);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;
                
                  case 't':
                    output[i] = ChooseMin(cal);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;


                   case 'p':
                    output[i] = ChooseMin(protein);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;

                   case 'P':
                    output[i] = ChooseMax(protein);
                 if(output[i]!=-1)
                   {
                    goto skip; 
                   }
                   break;
                  
                 default:
                  output[i] = 0;
                  break;
               }
             }
              if(output[i]==-1)
               {
                 output[i] = exceptional_case_item;
               }
             skip:
              e=0;
            for(int k=0;k<coll.Length;k++)
              coll[k] = 0;
           }
           }
           catch(Exception d)
            {
            Console.WriteLine(d);
            }
           return output;
       }
       // This method taking INPUT and returns an ARRAY of input
       public static int[] Input()
       {
        string tempInp =  Console.ReadLine();
        string[] tempInpStringArray = tempInp.Split(' ');
        int[] inp = new int[tempInpStringArray.Length];
        for(int i=0;i<tempInpStringArray.Length;i++)
         {
            inp[i] = Convert.ToInt32(tempInpStringArray[i]);
         }
         return inp;
       }

       // Main method  ,It contains Input logic ,method callings and display output logic
       public static void Main()
        {
          int[] protein = new int[50];
          int[] carbs = new int[50];
          int[] fat = new int[50];
        protein =   Input();
         carbs =  Input();
         fat =  Input();
         string diet = Console.ReadLine();
         string[] diet_plans = diet.Split(' ');
             int[] output = null;
         coll = new int[fat.Length];
         try{
         output = SelectMeals(protein,carbs,fat,diet_plans);
         for(int i=0;i<output.Length;i++)
          {
             if(output[i]==-1)
              output[i] = 0;
          }
         }
         catch(Exception e)
         {
            Console.WriteLine(e);
         }
         foreach(int i in output)
          Console.Write(i+" ");
        }
    }

