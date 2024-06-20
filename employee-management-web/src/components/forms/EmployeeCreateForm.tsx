import { Button, Container, CssBaseline, Grid, TextField } from '@mui/material';
import React, { useState } from 'react';
import ISkillCreateRequest from '../../models/employees/requests/ISkillCreateRequest';
import SeniorityRating from '../../models/enums/SeniorityRating';

interface IEmployeeCreateFormProps {
    onSubmit: () => void;

}



const EmployeeCreateForm = ({ onSubmit }: IEmployeeCreateFormProps) => {

    const [fname, setFname] = useState<string>("");
    const [lname, setLname] = useState<string>("");
    const [phone, setPhone] = useState<string>("");
    const [email, setEmail] = useState<string>("");
    const [dob, setDob] = useState<Date>();
    const [street, setStreet] = useState<string>();
    const [postalCode, setPostalCode] = useState<string>();
    const [country, setCountry] = useState<string>();

    const [skills, setSkills] = useState<ISkillCreateRequest[]>([]);

    

    // TODO: save items to localstorage on textfield blur
    const saveItemToLocalStorage = (itemName: string, itemValue: any) => {

    }

    const addSkill = (name: string, yearsOfExperience: number, seniorityRanking: SeniorityRating) => {
        const skill: ISkillCreateRequest = {
            name: name,
            yearsOfExperience: yearsOfExperience,
            rating: seniorityRanking
        };

        setSkills((prevState) => [...prevState, skill]);
    }
    return (
        <Container component="main" maxWidth="xs">
        <CssBaseline />
        <div style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center"
        }}>
          <form style={{
            width: "100%", // Fix IE 11 issue.
            marginTop: 3
          }} noValidate>
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  autoComplete="fname"
                  name="firstName"
                  variant="outlined"
                  required
                  fullWidth
                  id="firstName"
                  label="First Name"
                  autoFocus
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  variant="outlined"
                  required
                  fullWidth
                  id="lastName"
                  label="Last Name"
                  name="lastName"
                  autoComplete="lname"
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  variant="outlined"
                  required
                  fullWidth
                  id="email"
                  label="Email Address"
                  name="email"
                  autoComplete="email"
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  variant="outlined"
                  required
                  fullWidth
                  name="phone"
                  label="Contact Number"
                  id="phone"
                />
              </Grid>
             
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              style={{
                margin: 3
              }}
            >
              Save
            </Button>
          </form>
        </div>
      </Container>
    );
}

export default EmployeeCreateForm;