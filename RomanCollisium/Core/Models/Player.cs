using System.Text;
using Core.Interfaces;
using Core.Models.Cards;

namespace Core.Models;

public class Player
{
    private readonly ICardPickStrategy _strategy;
    private List<Card> _cards;

    protected Player(ICardPickStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ReceiveCards(List<Card> cards)
    {
        _cards = cards;
    }

    public int PickCard()
    {
        return _strategy.Pick(_cards.ToArray());
    }
    
    public void ShowCards()
    {
        StringBuilder str = new ();
        foreach (var card in _cards)
        {
            str.Append(card);
        }
        
        Console.Write(str);
    }

    public string GetStrategyName()
    {
        return _strategy.GetType().Name;
    }
}