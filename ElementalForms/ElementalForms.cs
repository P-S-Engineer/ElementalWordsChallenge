using static Preloaded.Elements;

namespace ElementalForms;

public class ElementalForms
{
    private static List<List<string>> recursiveElementalForms(string word, int idx)
    {
        //Create the variable to return at the end of the function
        List<List<string>> matches = new List<List<string>>();

        //an element could be 1, 2 or 3 letters long so create a list of the 3 possible elements from this idx
        List<string> possible_elements = new List<string>();
        for(int i=1; i <= 3; i++ )
        {
            if(word.Length >= idx + i)
            {
                //Element needs to be formatted so that the first letter is uppercase and the rest are lower case
                string formatted_element = string.Concat(word.Substring(idx,1).ToUpper(), word.Substring(idx+1, i-1).ToLower()); 
                possible_elements.Add(formatted_element);
            }
        }

        //Loop through all the elements and check if they are in the dict
        foreach(string element in possible_elements)
        {
            if(ELEMENTS.ContainsKey(element))
            {
                //We have a match
                //Check if we have reached the end of the word
                if(word.Length <= idx + element.Length)
                {   
                    matches.Add(new List<string>(){element});
                    continue;
                }

                //We havent reached the end of the word so check the next options
                List<List<string>> new_matches = recursiveElementalForms(word, idx+element.Length);

                //If new_matches is empty then nothing will be inserted to matches
                foreach(List<string> match in new_matches)
                {
                    //Add each of these new matches to the matches list
                    match.Insert(0, element);//O(n) time complexity! this could be improved if the word is very long.
                    matches.Add(match);
                }

            }
        }

        //If there were no matches then the return value will be empty
        return matches;
    }


    public static string[][] GetElementalForms(string word)
    {        
        //first call to the recursive function
        List<List<string>> forms = recursiveElementalForms(word, 0);

        //Format the List of Lists correctly
        string[][] result = new string[forms.Count][];
    
        for (int i = 0; i < forms.Count; i++)
        {
            List<string> form = forms[i];
            result[i] = new string[form.Count];

            for (int j=0; j < form.Count; j++)
            {
                string element = form[j];
                result[i][j] = ELEMENTS[element] + " (" + element + ")";
            }
        }
        return result;  
    }
}
