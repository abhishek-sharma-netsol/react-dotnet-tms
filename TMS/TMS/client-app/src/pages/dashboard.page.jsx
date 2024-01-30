import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { TaskOverview, Loader, TaskList } from "../components";
import { fetchTasks } from "../redux/task/task-actions";

const Dashboard = () => {
    const dispatch = useDispatch();

    // getting states
    const user = useSelector(s => s.auth.user);
    const { loading, error } = useSelector(s => s.task);

    useEffect(() => {
        dispatch(fetchTasks(user.id));
    }, [dispatch, user.id]);

    if (loading)
        return <Loader />

    if (error) {
        console.log(error);
        return;
    }

    return (
        <div className="container mx-auto px-4">
            <div className="">
                <TaskOverview />
                <TaskList />
            </div>
        </div>
    );
}

export default Dashboard;