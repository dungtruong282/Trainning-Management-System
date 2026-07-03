import axiosClient from "../api/axiosClient";

export const getCourses = async () => {
    const response = await axiosClient.get("/Courses");
    return response.data;
};