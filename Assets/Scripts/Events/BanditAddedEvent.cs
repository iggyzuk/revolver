using UnityEngine;

public class BanditMovedEvent : BaseEvent
{
    public int id;

    public BanditMovedEvent(int id)
    {
        this.id = id;
    }

    public void Execute(World model, WorldView view)
    {
        Bandit bandit = model.bandits[id];
        BanditView banditView = ViewService.GetBanditViewWithId(view, id);
        if (banditView != null)
        {
            banditView.UpdateHP(bandit.hp);
            banditView.GetComponentInChildren<MeshRenderer>().material.SetColor(
                "_Color",
                Color.Lerp(new Color32(200, 0, 65, 255), Color.white, (bandit.distance - Config.MIN_DISTANCE) / Config.SPAWN_RANGE)
            );
        }
    }
}
