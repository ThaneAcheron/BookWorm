using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


/// <summary>
/// Filename: FilterAlgorithm.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class contains the logic for building query strings 
/// </summary>
public class FilterAlgorithm
{
    //This variable is used to store a the new query string 
    string queryString;
	public FilterAlgorithm()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Filter (string SearchPhrase , string Genre , string OrderByPrefix, string OrderBySuffix )
    {
        //This code constructs the order by clause of the querystring 
         if(OrderByPrefix == "Name")
         {
             OrderByPrefix = "[BookName]";
         }
        if (OrderByPrefix == "Rating")
         {
             OrderByPrefix = "[BookAverageRating]";
         }
        if (OrderByPrefix == "Author")
         {
            OrderByPrefix = "[BookAuthor]";
         }


        //Check to see if there is a value within the textbox        
        if (SearchPhrase == "")
        {
            //If the genre all was selected display all the books else search for specific books/authors in that genre
            if (Genre == "All")
            {
                queryString = "SELECT [BookId], [BookName], [BookImageUrl], [BookAuthor], [BookAverageRating] FROM [BookInformation] ORDER BY " + OrderByPrefix + " " + OrderBySuffix;
            }
            else
            {
                queryString = "SELECT [BookId], [BookName], [BookImageUrl], [BookAuthor], [BookAverageRating] FROM [BookInformation] WHERE [BooKGenre] = '" + Genre + "'ORDER BY " + OrderByPrefix + " " + OrderBySuffix;
            }

        }
        //Otherwise just search by the genre selected
        else
        {
            //Same idea as above
            if (Genre == "All")
            {
                queryString = "SELECT [BookId], [BookName], [BookImageUrl], [BookAuthor], [BookAverageRating] FROM [BookInformation] WHERE [BookName] ='" + SearchPhrase + "' OR [BookAuthor] = '" + SearchPhrase + "'ORDER BY " + OrderByPrefix + " " + OrderBySuffix;
            }
            else
            {
                queryString = "SELECT [BookId], [BookName], [BookImageUrl], [BookAuthor], [BookAverageRating] FROM [BookInformation] WHERE [BookName] = '" + SearchPhrase + "' OR [BookAuthor] = '" + SearchPhrase + "' AND [BooKGenre] = '" + Genre + "'ORDER BY " + OrderByPrefix + " " + OrderBySuffix;
            }
        }
        //Return the querystring
        return queryString;
    }
}