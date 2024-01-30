const TaskDetails = ({ task }) => {
    return (
        <div className="bg-white shadow-md rounded-md p-8">
            <h2 className="text-2xl font-bold mb-4">{task.title}</h2>
            <div className="grid grid-cols-2 gap-4">
                <div className="col-span-1">
                    <p className="text-lg font-semibold mb-2">Description:</p>
                    <p className="text-gray-800">{task.description}</p>
                </div>
                <div className="col-span-1">
                    <p className="text-lg font-semibold mb-2">Due Date:</p>
                    <p className="text-gray-800">{task.dueDate}</p>
                </div>
            </div>
            <div className="grid grid-cols-2 gap-4 mt-4">
                <div className="col-span-1">
                    <p className="text-lg font-semibold mb-2">Priority:</p>
                    <p className="text-gray-800">{task.priority}</p>
                </div>
                <div className="col-span-1">
                    <p className="text-lg font-semibold mb-2">Status:</p>
                    <p className="text-gray-800">{task.status}</p>
                </div>
            </div>
            {/* Add comments and attachments display here */}
        </div>
    );
};

export default TaskDetails;
