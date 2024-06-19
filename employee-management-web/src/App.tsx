
//MRT Imports
import React, { useEffect, useState } from "react";
import './styles/app.css';
import Stack from '@mui/material/Stack';
import Grid from '@mui/material/Unstable_Grid2';

import EmployeeResponse from "./models/employees/responses/EmployeeResponse";

import EmployeesTable from "./components/table/EmployeesTable";
import { GetEmployees } from "./api/EmployeeAPI";
import { Box, Button, InputAdornment, Modal, TextField } from "@mui/material";
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import SearchIcon from '@mui/icons-material/Search';
import EmployeeCreateForm from "./components/forms/EmployeeCreateForm";

const style = {
  position: 'absolute' as 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

function App() {

  const [employees, setEmployees] = useState<EmployeeResponse[]>([]);
  const [selectedEmployee, setSelectedEmployee] = useState<string>();
  const [isModalOpen, setModalOpen] = useState<boolean>(false);

  useEffect(() => {
    async function loadEmployees() {
      const apiData = await GetEmployees();
      setEmployees(apiData);
    }

    loadEmployees().catch(err => console.log(`Error fetching employees: ${err}`));
  }, []);

  const onClickEdit = (row: EmployeeResponse): void => {

  }

  const handleEmployeeCreation = () => {}




  return (
    <div className="centered-content">
      <Stack spacing={3}>
        {/* Filter box + sort button + add button */}
        <Grid container spacing={3}>
          <Grid xs={2} md={2} lg={2}>
            <h3>Employees</h3><br />
          </Grid>
          <Grid xs={6} md={7} lg={7}>
            <TextField id="search" fullWidth size={'small'} label="Search" variant="outlined" 
              InputProps={{
                startAdornment: <InputAdornment position="start"><SearchIcon /></InputAdornment>
              }}
              />
          </Grid>
          
          <Grid xs={4} md={3} lg={3}>
            <Button size={'medium'} variant="contained" startIcon={<AddCircleOutlineIcon />} onClick={() => setModalOpen(true)}>Create</Button>
          </Grid>
        </Grid>


        {/* Table component */}
        <EmployeesTable rows={employees} onEdit={onClickEdit} />

        {/* Drawer goes here */}
        <Modal open={isModalOpen} onClose={() => setModalOpen(false)} disableEnforceFocus>
          <Box sx={style}>
            <EmployeeCreateForm onSubmit={handleEmployeeCreation} />
          </Box>
        </Modal>

      </Stack>
    </div>
  );
}

export default App;
