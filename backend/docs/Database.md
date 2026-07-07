# Database Design

## Project

Training Management System

## Purpose

This database is designed for an internal training management system used by an enterprise or construction company.  
The system manages departments, employees, courses, lessons, enrollments, and quizzes.

---

# 1. Tables

## 1.1 Department

Stores company departments.

| Field | Type | Key | Description |
|------|------|-----|-------------|
| Id | int | PK | Department ID |
| Name | string |  | Department name |
| Description | string |  | Department description |
| CreatedAt | datetime |  | Created date |
| UpdatedAt | datetime |  | Last updated date |

---

## 1.2 User

Stores employee accounts.

| Field | Type | Key | Description |
|------|------|-----|-------------|
| Id | int | PK | User ID |
| FullName | string |  | Employee full name |
| Email | string |  | Login email |
| PasswordHash | string |  | Hashed password |
| Phone | string |  | Phone number |
| Role | string |  | Admin, HR, Trainer, Employee |
| Status | string |  | Active or Inactive |
| DepartmentId | int | FK | References Department |
| CreatedAt | datetime |  | Created date |

---

## 1.3 Course

Stores training courses.

| Field | Type | Key | Description |
|------|------|-----|-------------|
| Id | int | PK | Course ID |
| Title | string |  | Course title |
| Description | string |  | Course description |
| CreatedAt | datetime |  | Created date |
| CreatedByUserId | int | FK | User who created the course |

---

## 1.4 Lesson

Stores lessons inside a course.

| Field | Type | Key | Description |
|------|------|-----|-------------|
| Id | int | PK | Lesson ID |
| Title | string |  | Lesson title |
| Content | string |  | Lesson content |
| CourseId | int | FK | References Course |
| OrderNumber | int |  | Lesson order |

---

## 1.5 Enrollment

Stores course registration and learning progress.

| Field | Type | Key | Description |
|------|------|-----|-------------|
| Id | int | PK | Enrollment ID |
| UserId | int | FK | References User |
| CourseId | int | FK | References Course |
| Status | string |  | NotStarted, InProgress, Completed |
| EnrollDate | datetime |  | Enrollment date |
| CompletedDate | datetime |  | Completion date |

---

## 1.6 Quiz

Stores quizzes for lessons.

| Field | Type | Key | Description |
|------|------|-----|-------------|
| Id | int | PK | Quiz ID |
| LessonId | int | FK | References Lesson |
| Title | string |  | Quiz title |
| Description | string |  | Quiz description |
| PassingScore | int |  | Minimum passing score |
| TimeLimit | int |  | Time limit in minutes |

---

# 2. Relationships

## Department - User

One department has many users.

```text
Department (1) ---- (N) User
```

A user belongs to one department.

---

## User - Course

A user can create many courses.

```text
User (1) ---- (N) Course
```

The `CreatedByUserId` field in `Course` references `User.Id`.

---

## Course - Lesson

One course has many lessons.

```text
Course (1) ---- (N) Lesson
```

A lesson belongs to one course.

---

## Lesson - Quiz

One lesson can have many quizzes.

```text
Lesson (1) ---- (N) Quiz
```

A quiz belongs to one lesson.

---

## User - Course through Enrollment

A user can enroll in many courses.  
A course can have many users.

This is a many-to-many relationship handled by the `Enrollment` table.

```text
User (N) ---- (N) Course

User ---- Enrollment ---- Course
```

---

# 3. ERD Overview

```text
Department
    |
    | 1 - N
    |
User
    |
    | 1 - N
    |
Course
    |
    | 1 - N
    |
Lesson
    |
    | 1 - N
    |
Quiz


User
    |
    | N - N
    |
Course
    |
Enrollment
```

---

# 4. Notes

- `PasswordHash` is used instead of plain password for security.
- `Enrollment` is used to manage the many-to-many relationship between users and courses.
- `Status` in `Enrollment` is used to track learning progress.
- `CreatedAt` and `UpdatedAt` help track data history.
- `CreatedByUserId` helps identify the trainer or admin who created a course.