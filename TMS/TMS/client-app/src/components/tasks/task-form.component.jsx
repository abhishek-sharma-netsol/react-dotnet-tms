import { useState } from "react";
import Button from "../button.component";
import Input from "../input.component";

const TaskForm = ({ onSubmit, initialValues }) => {
    const [values, setValues] = useState(initialValues || {});

    const handleChange = (e) => {
        setValues({ ...values, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(values);
    };

    return (
        <form onSubmit={handleSubmit} className="rounded-lg p-6 bg-white">
            <div className="grid grid-cols-1 gap-4">
                <Input label="Title: " />
                <div className="mb-2">
                    <label className="block text-lg font-semibold mb-2">Description:</label>
                    <textarea
                        name="description"
                        value={values.description || ''}
                        onChange={handleChange}
                        className="border border-gray-300 rounded-md p-2 w-full"
                        rows="2"
                    ></textarea>
                </div>
                <Input label="Due Date: " type="date" />

                <div className="mb-2">
                    <p className="block text-sm font-bold mb-2">Priority</p>
                    <div className="grid grid-cols-3 gap-4">
                        <div className="flex items-center">
                            <input type="radio" id="low" name="priority" value="low" className="mr-2 cursor-pointer" />
                            <label htmlFor="low" className="cursor-pointer">Low</label>
                        </div>

                        <div>
                            <input type="radio" id="medium" name="priority" value="medium" className="mr-2 cursor-pointer" />
                            <label htmlFor="medium" className="cursor-pointer">Medium</label>
                        </div>

                        <div>
                            <input type="radio" id="high" name="priority" value="high" className="mr-2 cursor-pointer" />
                            <label htmlFor="high" className="cursor-pointer">High</label>
                        </div>
                    </div>
                </div>

                <div className="mb-2">
                    <p className="block text-sm font-bold mb-2">Status</p>
                    <div className="grid grid-cols-3 gap-4">
                        <div className="flex items-center">
                            <input type="radio" id="todo" name="status" value="todo" className="mr-2 cursor-pointer" />
                            <label htmlFor="todo" className="cursor-pointer">To Do</label>
                        </div>

                        <div className="flex items-center">
                            <input type="radio" id="in-progress" name="status" value="in-progress" className="mr-2 cursor-pointer" />
                            <label htmlFor="in-progress" className="cursor-pointer">In Progress</label>
                        </div>

                        <div className="flex items-center">
                            <input type="radio" id="completed" name="status" value="completed" className="mr-2 cursor-pointer" />
                            <label htmlFor="completed" className="cursor-pointer">Completed</label>
                        </div>
                    </div>
                </div>
            </div>
            <div className="mt-4">
                <Button>Submit</Button>
            </div>
        </form>
    );
};

export default TaskForm;
