using System;
using System.Collections.Generic; //to use List
using System.Linq; //to use OrderBy to randomize List

public enum eFace
{ //face value of card
	ace = 1,
	Two = 2,
	three = 3,
	four = 4,
	five = 5,
	six = 6,
	seven = 7,
	eight = 8,
	nine = 9,
	ten = 10,
	jack = 11,
	queen = 12,
	king = 13
}

public enum eSuit
{ //suit of card
	hearts,
	diamonds,
	clubs,
	spades
}

public class Card
{ //creating Card class object to hold face and suit values
	public eFace Face;
	public eSuit Suit;
	public Card(eFace face, eSuit suit)
	{
		Face = face;
		Suit = suit;
	}
}

public class Deck
{ //create Deck class object to hold Cards class
	public List<Card> Cards = new List<Card>(); //import System.Collections.Generic
	public void populateDeck()
	{ //populate the deck with face cards and their associated suits
		var eFaceValues = Enum.GetValues(typeof(eFace)); //enumerate enums with public static Array GetValues (Type enumType);
		var eSuitValues = Enum.GetValues(typeof(eSuit)); //enumerate enums with public static Array GetValues (Type enumType);
		foreach (var currentFace in eFaceValues)
		{ //loop through each face card (ie. ace, two...)
			foreach (var currentSuit in eSuitValues)
			{ //loop through each suit for each face card (ie. heart, spades...)
				Card currentCard = new Card((eFace)currentFace, (eSuit)currentSuit);
				Cards.Add(currentCard); //push to list array - List<Card> Cards
			}
		}
	}

	public void shuffle()
	{ //shuffle deck with Random Class and Linq queries; 
		var rnd = new Random();
		var randomizedDeck = Cards.OrderBy(item => rnd.Next()); //import System.Linq to use public OrderBy(IEnumerable<TSource> source, Func<TSource,TKey> keySelector);
		Cards = randomizedDeck.ToList(); //convert Linq type query return to List<Card>
	}

	public void deal_one_card()
	{ //deal one card from deck
		if (Cards.Count() > 0)
		{ //check to make sure we have cards to deal from deck
			Console.WriteLine("Card dealt: " + Cards.ElementAt(0).Face + ", " + Cards.ElementAt(0).Suit); //get card @ index 0 before removing from deck 
			Cards.RemoveAt(0); //removed from deck
		}
		else
		{ //if no cards are found in deck
			Console.WriteLine("No more cards in deck to deal!");
		}

		printDeckDetails();
	}

	public void printDeck()
	{ //print to console of entire deck - List<Card> Cards
		foreach (var card in Cards)
		{ //loop through each card in deck - List<Card> Cards
			Console.WriteLine("Card: " + card.Face + ", " + card.Suit);
		}
	}

	public void printDeckCount()
	{ //gets count of cards in deck - List<Card> Cards
		Console.WriteLine("Deck Count: " + Cards.Count + "\n");
	}

	public void printDeckDetails()
	{ //give me the juice
		Console.WriteLine("printDeckDetails................");
		printDeck();
		printDeckCount();
	}
}

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World\n");
		Deck d1 = new Deck();
		d1.populateDeck();
		d1.printDeckDetails();
		//d1.shuffle();
		//Console.WriteLine("\nShuffled Deck........................");
		d1.printDeckDetails();
		for (int i = 0; i < d1.Cards.Count(); i++)
		{
			d1.deal_one_card();
		}
	}
}