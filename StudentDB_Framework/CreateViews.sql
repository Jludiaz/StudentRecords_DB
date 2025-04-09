CREATE VIEW vw_StudentScholarships AS
SELECT 
    s.gwid,
    s.first,
    s.last,
    sh.SID,
    sh.Amount,
    sh.Length
FROM Students s
JOIN Has h ON s.gwid = h.GWID
JOIN Scholarships sh ON h.SID = sh.SID;
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
JOIN MustPay mp ON s.gwid = mp.GWID
JOIN Payments p ON mp.PID = p.pid;
GO