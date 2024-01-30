import { useState } from "react";
import Button from "../button.component";
import TaskForm from "./task-form.component";
import Modal from "../modal.component";
import Map from '../../helpers/common.helpers';
import { useSelector } from "react-redux";
import Loader from "../loader.component";

const TaskList = () => {
    const { tasks, loading } = useSelector(s => s.task);
    const [modalIsOpen, setIsOpen] = useState(false);

    if (loading)
        return <Loader />

    return (
        <div className="bg-white rounded-lg shadow-md p-6 mb-6">
            <div className="flex justify-between items-center mb-4 text-center">
                <h2 className="text-xl font-bold">Task List</h2>
                <Button className="px-6 font-bold" onClick={() => setIsOpen(true)}>Add Task</Button>
            </div>
            <ul>
                {tasks.map(task => (
                    <li key={task.id} className="border rounded-lg hover:cursor-pointer hover:shadow-md 
                    p-4 mb-4 flex items-center justify-between">
                        <div>
                            <div className="text-lg font-semibold mb-1">{task.title}</div>
                            <div className="text-sm mb-1">Due Date: {task.dueDate}</div>
                            <div className="text-sm mb-1">Priority: {`${Map.priority[task.priority]}`}</div>
                            <div className="text-sm">Status: {`${Map.status[task.status]}`}</div>
                        </div>
                        <div className="flex flex-col justify-between gap-4">
                            <Button className="">Edit</Button>
                            <Button>Delete</Button>
                        </div>
                    </li>
                ))}
            </ul>

            <Modal
                isOpen={modalIsOpen}
                onClose={() => setIsOpen(false)}
                title="Create Task"
                buttonText="Cancel"
            >
                <TaskForm />
            </Modal>
        </div>
    );
};

export default TaskList;