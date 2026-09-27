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
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Idle, ActionDuration = 0.5f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Bounce, ActionDuration = 0.5f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Attack, ActionDuration = 2f }
                    }
                };
            case WorkerBeeType.Sway:
                return new WorkerBeeBehaviour
                {
                    Actions = new WorkerBeeAction[]
                    {
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Idle, ActionDuration = 0.5f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Bounce, ActionDuration = 0.5f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Sway, ActionDuration = 2f }
                    }
                };
            case WorkerBeeType.Fire:
                return new WorkerBeeBehaviour
                {
                    Actions = new WorkerBeeAction[]
                    {
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Idle, ActionDuration = 0.5f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Bounce, ActionDuration = 0.5f },
                        new WorkerBeeAction { ActionName = WorkerBeeActionType.Shoot, ActionDuration = 2f }
                    }
                };
            default:
                throw new System.ArgumentException("Invalid worker bee type");
        }
    }



}
