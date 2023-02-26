import {memo} from "react";
import {styled} from '@mui/material/styles';

const Root = styled('div')(({theme, config}) => ({
    ...(config.mode === 'boxed' && {
        clipPath: 'inset(0)',
        maxWidth: `${config.containerWidth}px`,
        margin: '0 auto',
        boxShadow: '0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06)',
    }),
    ...(config.mode === 'container' && {
        '& .container': {
            maxWidth: `${config.containerWidth}px`,
            width: '100%',
            margin: '0 auto',
        },
    }),
}));

function Layout1(props) {
    return (
        <Root id="ng-layout" className="w-full flex">

        </Root>
    )
}

export default memo(Layout1);
