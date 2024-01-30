import { useSelector } from "react-redux";

const TaskOverview = () => {
    const { tasks, loading, error } = useSelector(s => s.task);

    const totalTasks = tasks.length;
    const completedTasks = tasks.filter(task => task.status === 1).length;
    const inProgressTasks = tasks.filter(task => task.status === 2).length;
    const pendingTasks = tasks.filter(task => task.status === 0).length;


    const tTasks = [
        { type: "Total Tasks", noOfTasks: totalTasks },
        { type: "Completed Tasks", noOfTasks: completedTasks },
        { type: "In Progress Tasks", noOfTasks: inProgressTasks },
        { type: "Pending Tasks", noOfTasks: pendingTasks }
    ];

    return (
        <div className="bg-white rounded-lg shadow-md p-6 mb-6">
            <h2 className="text-xl font-bold mb-4">Task Overview</h2>
            <div className="grid grid-cols-2 sm:grid-cols-4 gap-4">
                {tTasks.map((item, index) => (
                    <div key={index}
                        className="border rounded-lg p-4 flex flex-col justify-center 
                        hover:cursor-pointer hover:shadow-md"
                    >
                        <p className="text-lg font-semibold mb-2">{item.type}</p>
                        <p className="text-lg">{item.noOfTasks}</p>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default TaskOverview;
