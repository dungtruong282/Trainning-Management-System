import { useEffect, useState } from "react";
import MainLayout from "../../components/layout/MainLayout";
import { getUsers } from "../../services/userService";
import { getDepartments } from "../../services/departmentService";
import { getCourses } from "../../services/courseService";

export default function Dashboard() {
    const [stats, setStats] = useState({
        users: 0,
        departments: 0,
        courses: 0
    });

    useEffect(() => {
        Promise.all([getUsers(), getDepartments(), getCourses()])
            .then(([users, departments, courses]) => {
                setStats({
                    users: users.length,
                    departments: departments.length,
                    courses: courses.length
                });
            })
            .catch((error) => console.log(error));
    }, []);

    return (
        <MainLayout>
            <h1>Dashboard</h1>
            <p>Welcome to Training Management System.</p>

            <div style={styles.grid}>
                <div style={styles.card}>
                    <p>Total Users</p>
                    <h2>{stats.users}</h2>
                </div>

                <div style={styles.card}>
                    <p>Total Departments</p>
                    <h2>{stats.departments}</h2>
                </div>

                <div style={styles.card}>
                    <p>Total Courses</p>
                    <h2>{stats.courses}</h2>
                </div>
            </div>
        </MainLayout>
    );
}

const styles = {
    grid: {
        display: "grid",
        gridTemplateColumns: "repeat(3, 1fr)",
        gap: "20px",
        marginTop: "24px"
    },
    card: {
        background: "white",
        padding: "24px",
        borderRadius: "12px",
        boxShadow: "0 4px 12px rgba(0,0,0,0.08)"
    }
};
