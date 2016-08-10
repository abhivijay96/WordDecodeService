-- Primary Data Tables --

CREATE TABLE IF NOT EXISTS refdata (
    id uuid PRIMARY KEY,
    v int NOT NULL,
    ts timestamp with time zone NOT NULL,
    data jsonb NOT NULL
);

-- Index Tables --

CREATE TABLE IF NOT EXISTS refdata_inv (
    oid uuid NOT NULL,
    id uuid NOT NULL,
    v int NOT NULL,
    score int NOT NULL,
    seq serial,
    data jsonb,
    UNIQUE (oid, id)
);

CREATE INDEX IF NOT EXISTS refdata_inv_oid_idx ON refdata_inv (oid, score DESC, seq ASC);

CLUSTER refdata_inv USING refdata_inv_oid_idx;

-- Misc --

ALTER TABLE refdata OWNER TO "ReferenceDataService";
ALTER TABLE refdata_inv OWNER TO "ReferenceDataService";
