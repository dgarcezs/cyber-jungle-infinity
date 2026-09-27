public class WorkerBeeBehaviourFactory
{
    public static WorkerBeeBehaviour GetWorkerBeeBehaviour(WorkerBeeType type)
    { 
        switch (type)
        {
            case WorkerBeeType.Common:
                return new WorkerBeeBehaviour
                {
                    Actions = new WorkerBeeAction[]
                    {
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Idle, ActionDuration = 1f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Bounce, ActionDuration = 1f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Attack, ActionDuration = 1f }
                    }
                };
            case WorkerBeeType.Sway:
                return new WorkerBeeBehaviour
                {
                    Actions = new WorkerBeeAction[]
                    {
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Idle, ActionDuration = 1f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Bounce, ActionDuration = 1f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Sway, ActionDuration = 1f }
                    }
                };
            case WorkerBeeType.Fire:
                return new WorkerBeeBehaviour
                {
                    Actions = new WorkerBeeAction[]
                    {
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Idle, ActionDuration = 1f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Bounce, ActionDuration = 1f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Shoot, ActionDuration = 2f }
                    }
                };
            default:
                throw new System.ArgumentException("Invalid worker bee type");
        }
    }



}
