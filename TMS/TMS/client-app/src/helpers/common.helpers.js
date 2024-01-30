import Constants from "./constants.helpers";

class Map {
    static priority = {
        0: Constants.Priority.Low,
        1: Constants.Priority.Medium,
        2: Constants.Priority.High,
    };

    static status = {
        0: Constants.Status.Pending,
        1: Constants.Status.Completed,
        2: Constants.Status.InProgress,
    }
}

// const toPriority = (x) => priorityMap[x];
// const toStatus = (x) => statusMap[x];

export default Map;