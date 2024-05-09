import { Stack, Toolbar } from '@mui/material';
import React from 'react';
import { Link } from 'react-router-dom';
import s from './Header.module.css'
import LoginModal from './modals/LoginModal';
import GarageModal from './modals/GarageModal';
import { HeaderWrapper, MainWrapper, StyledAppBar, ToolbarTitle } from './HeaderStyles';

interface Props {
  title: string;
}

export const Header: React.FC<Props> = ({ title }): JSX.Element => {

  return (
    <>
      <HeaderWrapper>
        <StyledAppBar>
          <Toolbar variant='regular'>
            <MainWrapper>
              <Stack sx={{ flexGrow: 1 }}>
                <Link to={"/"} className={s.link}>
                  <ToolbarTitle>
                    {title}
                  </ToolbarTitle>
                </Link>
              </Stack>
              <Stack direction="row" spacing={2} >
                <GarageModal />
                <LoginModal />
              </Stack>
            </MainWrapper>
          </Toolbar>
        </StyledAppBar>
      </HeaderWrapper>
    </>
  )
}