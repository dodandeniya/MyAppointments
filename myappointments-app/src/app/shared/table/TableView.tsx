import {
  IconButton,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@material-ui/core";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import React from "react";

export interface ITableViewProps {
  data: Array<any>;
  canEdit?: boolean;
  canDelete?: boolean;
  onEdit: (item: any) => void;
  onDelete: (item: any) => void;
}

export default function TableView(props: ITableViewProps) {
  const getKeys = () => {
    return Object.keys(props.data[0]);
  };

  const getHeader = () => {
    var keys = getKeys();

    if (props.canEdit) keys.push("edit");
    if (props.canDelete) keys.push("delete");

    return keys.map((key, index) => {
      return <TableCell key={index}>{key.toUpperCase()}</TableCell>;
    });
  };

  const getRowsData = () => {
    var items = props.data;
    var keys = getKeys();

    if (props.canEdit) keys.push("edit");
    if (props.canDelete) keys.push("delete");

    return items.map((row, rowIndex) => {
      return (
        <TableRow key={rowIndex}>
          {keys.map((key, index) => {
            if (key === "id")
              return <TableCell key={index}>{rowIndex + 1}</TableCell>;

            if (key === "edit" && props.canEdit) {
              return (
                <TableCell key={index}>
                  <IconButton onClick={() => props.onEdit(row)}>
                    <EditIcon fontSize="small" />
                  </IconButton>
                </TableCell>
              );
            }

            if (key === "delete" && props.canDelete) {
              return (
                <TableCell key={index}>
                  <IconButton onClick={() => props.onDelete(row)}>
                    <DeleteIcon fontSize="small" />
                  </IconButton>
                </TableCell>
              );
            }

            return <TableCell key={index}>{row[key]}</TableCell>;
          })}
        </TableRow>
      );
    });
  };

  return (
    <Table aria-label="categories table" size="small">
      <TableHead>
        <TableRow>{getHeader()}</TableRow>
      </TableHead>
      <TableBody>{getRowsData()}</TableBody>
    </Table>
  );
}
