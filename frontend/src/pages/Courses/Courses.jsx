import { useEffect, useState } from "react";
import MainLayout from "../../components/layout/MainLayout";
import { getCourses } from "../../services/courseService";

export default function Courses() {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        getCourses()
            .then(setCourses)
            .catch((error) => console.log(error));
    }, []);

    return (
        <MainLayout>
            <h1>Courses Management</h1>

            <div style={{ background: "white", padding: "20px", borderRadius: "12px" }}>
                <table style={{ width: "100%", borderCollapse: "collapse" }}>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>Created By</th>
                            <th>Created At</th>
                        </tr>
                    </thead>

                    <tbody>
                        {courses.map((course) => (
                            <tr key={course.id}>
                                <td>{course.id}</td>
                                <td>{course.title}</td>
                                <td>{course.description}</td>
                                <td>{course.createdByUserName}</td>
                                <td>{new Date(course.createdAt).toLocaleDateString()}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </MainLayout>
    );
}