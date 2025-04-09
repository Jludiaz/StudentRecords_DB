CREATE VIEW vw_StudentScholarships AS
SELECT 
    s.gwid,
    s.first,
    s.last,
    sh.sid,
    sh.amount,
    sh.length
FROM Students s
JOIN Has h ON s.gwid = h.gwid
JOIN Scholarships sh ON h.sid = sh.sid;
GO

CREATE VIEW vw_StudentPayments AS
SELECT 
    s.gwid,
    s.first,
    s.last,
    p.pid,
    p.payment_type,
    p.amount_due,
    p.due_date
FROM Students s
JOIN MustPay mp ON s.gwid = mp.gwid
JOIN Payments p ON mp.pid = p.pid;
GO