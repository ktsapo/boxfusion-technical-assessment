import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import EmployeeResponse from '../../models/employees/responses/EmployeeResponse';
import { IconButton } from '@mui/material';
import BorderColorIcon from '@mui/icons-material/BorderColor';

interface IEmployeesTableProps {
    rows: EmployeeResponse[];
    onEdit: (item: EmployeeResponse) => void;
}

const EmployeesTable = ({ rows, onEdit }: IEmployeesTableProps) => {
    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell></TableCell>
                        <TableCell>First name</TableCell>
                        <TableCell>Last name</TableCell>
                        <TableCell>Contact number</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map((employee, index) => (
                        <TableRow key={index}  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                            <TableCell component="th" scope="row">
                                <IconButton onClick={() => onEdit(employee)}>
                                    <BorderColorIcon />
                                </IconButton>
                            </TableCell>
                            <TableCell>
                                {employee.firstName}
                            </TableCell>
                            <TableCell>{employee.lastName}</TableCell>
                            <TableCell>{employee.contactNumber}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}
export default EmployeesTable;