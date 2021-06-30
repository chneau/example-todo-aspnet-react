import { gql, useQuery } from "@apollo/client";
import React from "react";
import { Table } from "react-bootstrap";

interface TodoItem {
  id: string;
  description: string;
}
interface TodoItemData {
  todoItems: TodoItem[];
}

export const TestingPage = () => {
  const { loading, data } = useQuery<TodoItemData>(gql`
    query GetTodoItemsDescriptions {
      todoItems {
        id
        description
      }
    }
  `);

  if (loading) {
    return <div>Loading ...</div>;
  }

  if (data == null) {
    return <div>No data found ...</div>;
  }

  console.log(data.todoItems);

  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>ID</th>
          <th>Description</th>
        </tr>
      </thead>
      <tbody>
        {data.todoItems.map((x) => (
          <tr>
            <td>{x.id}</td>
            <td>{x.description}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};
