
import PropTypes from 'prop-types';
import { Suspense } from 'react';
import NGLoading from "../NGLoading";


/**
 * React Suspense defaults
 * For to Avoid Repetition
 */ function NGSuspense(props) {
    return <Suspense fallback={<NGLoading {...props.loadingProps} />}>{props.children}</Suspense>;
}

NGSuspense.propTypes = {
    loadingProps: PropTypes.object,
};

NGSuspense.defaultProps = {
    loadingProps: {
        delay: 0,
    },
};

export default NGSuspense;
