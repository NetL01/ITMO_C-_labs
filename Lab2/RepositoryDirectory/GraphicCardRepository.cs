using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class GraphicCardRepository : IRepository<GraphicsCard>
{
    private static GraphicCardRepository? _instance;
    private Collection<GraphicsCard> _graphicsCard;

    private GraphicCardRepository()
    {
        _graphicsCard = new();
        GraphicsCard computerCase = new GraphicsCardBuilder()
            .WithName("4090 GameRock")
            .WithChipFrequency(3600)
            .WithPowerConsumption(300)
            .WithGraphicsCardSize(new GraphicsCardDimentions(1, 1))
            .WithPciExpressVersion(12)
            .WithVideoMemorySize(12123123)
            .Build();

        _graphicsCard.Add(computerCase);
    }

    public static GraphicCardRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new GraphicCardRepository();
            return _instance;
        }
    }

    public void Add(GraphicsCard newComponent)
    {
        _graphicsCard.Add(newComponent);
    }

    public GraphicsCard? Receive(string name)
    {
        foreach (GraphicsCard graphicsCard in _graphicsCard)
        {
            if (name == graphicsCard.Name) return graphicsCard;
        }

        return null;
    }
}