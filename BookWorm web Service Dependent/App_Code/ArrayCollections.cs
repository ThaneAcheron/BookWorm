using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Filename: ArrayCollections.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the arraylist values for the genrelist and securityQuestions list
/// </summary>
public class ArrayCollections
{
	public ArrayCollections()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public ArrayList GenreList()
    {
        //This method returns an arraylist that contains all the genre values
        ArrayList DdlGenreArray = new ArrayList();

        DdlGenreArray.Add("All");
        DdlGenreArray.Add("Action and Adventure");
        DdlGenreArray.Add("Anthologies");
        DdlGenreArray.Add("Art");
        DdlGenreArray.Add("Autobiographies");
        DdlGenreArray.Add("Biographies");
        DdlGenreArray.Add("Childrens books");
        DdlGenreArray.Add("Comics");
        DdlGenreArray.Add("Cookbooks");
        DdlGenreArray.Add("Diaries");
        DdlGenreArray.Add("Dictionaries");
        DdlGenreArray.Add("Drama");
        DdlGenreArray.Add("Encyclopedias");
        DdlGenreArray.Add("Fantasy");
        DdlGenreArray.Add("Guide");
        DdlGenreArray.Add("History");
        DdlGenreArray.Add("Horror");
        DdlGenreArray.Add("Journals");
        DdlGenreArray.Add("Math");
        DdlGenreArray.Add("Mystery");
        DdlGenreArray.Add("Poetry");
        DdlGenreArray.Add("Prayer books");
        DdlGenreArray.Add("Religious");
        DdlGenreArray.Add("Romance");
        DdlGenreArray.Add("Satire");
        DdlGenreArray.Add("Science fiction");
        DdlGenreArray.Add("Science");
        DdlGenreArray.Add("Self help");
        DdlGenreArray.Add("Series");
        DdlGenreArray.Add("Travel");
        DdlGenreArray.Add("Trilogies");
        DdlGenreArray.Add("Other");

        return DdlGenreArray;
    }

    public ArrayList SecurityQuestions()
    {
        //This method returns an arraylist that contains all the security quesitions 
        ArrayList SecurityQuestionsList = new ArrayList();

        SecurityQuestionsList.Add("City you were born");
        SecurityQuestionsList.Add("Province you were born");
        SecurityQuestionsList.Add("Favourite cousin");
        SecurityQuestionsList.Add("Street you grew up in");
        SecurityQuestionsList.Add("Child hood hero");
        SecurityQuestionsList.Add("Elementary school name");
        SecurityQuestionsList.Add("Primary school name");

        return SecurityQuestionsList; 
    }
}