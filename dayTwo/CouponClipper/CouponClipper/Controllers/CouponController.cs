//Todo- R
#pragma warning disable 8629
using Microsoft.AspNetCore.Mvc;   //* Controller, Http(Get/), IActionResult, View, HttpContext, ModelState, RedirectToAction
//Todo- Context/_context?
using CouponClipper.Models;
using Microsoft.EntityFrameworkCore;//* .Include

namespace CouponClipper.Controllers;

//* Coupon Class Containing methods
public class CouponController : Controller
{
    //TODO- Explain code within this.scope; whyNot readonly(IDE recommends) MyContext?
    private readonly MyContext _context;

    //? Not used: "_logger"
        //? Kept for future debugging, 
        //? Interface && Children loggers, 
        //? diagnosing in Prod Env, 
    private readonly ILogger<CouponController> _logger;

    public CouponController(ILogger<CouponController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //* Homepage ACTION
    [HttpGet("coupon/dashboard")]
    public IActionResult Dashboard()
    {
        //* LINQ Lambda in SQL form- 
        //* SELECT *
        //* FROM Coupons
        //* INNER JOIN Organizers ON Coupons.OrganizerId = Organizers.Id
        //* INNER JOIN CouponUsers ON Coupons.Id = CouponUsers.CouponId;
        List<Coupon> AllCoupons = _context.Coupons.Include(coup => coup.Organizer).Include(coup => coup.AllUsers).ToList();

        return View(AllCoupons);
    }

    //* GetOneCouponById ACTION
    [HttpGet("coupon/view/{id}")]
    public IActionResult ViewCoupon(int id)
    {
        //TODO- Explain code within this.scope
        Coupon? coup = _context.Coupons.Include(p => p.Organizer)
                                        .Include(p => p.AllUsers)
                                        .ThenInclude(mid => mid.User)
                                        .FirstOrDefault(p => p.CouponId == id);
        if (coup == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View(coup);
    }

    //* AddOne view ACTION
    [HttpGet("coupon/new")]
    public IActionResult AddCoupon()
    {
        return View();
    }

    //* AddCoupon ACTION
    [HttpPost("coupon/create")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        //TODO- Can we put 69 into 72??
        int UserId = (int)HttpContext.Session.GetInt32("UserId"); //* Retrieve Int("UserId") to create instance of userId 
        if (ModelState.IsValid)                                   //Todo- If (currently migrated data model)
        {
            newCoupon.UserId = UserId;
            _context.Add(newCoupon);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        return View("AddCoupon");
    }

    //Todo- Explain this Action/View
    [HttpPost("coupon/{id}/iUA")]
    public IActionResult AddUser(int id)
    {
        int UUID = (int)HttpContext.Session.GetInt32("UserId");
        CouponHasUsers iUA = _context.CouponHasUsers.FirstOrDefault(r => r.CouponId == id && r.UserId == UUID);
        if (iUA == null)
        {
            CouponHasUsers isiUAd = new()
            {
                UserId = UUID,
                CouponId = id
            };
            _context.Add(isiUAd);
            
        } else {
            _context.Remove(iUA);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    //* Action- DeleteOneCouponById
    [HttpPost("coupon/{id}/destroy")]
    public IActionResult DeleteCoupon(int id)
    {
        //Todo- Explain this block(LINQ DQL?) 
        Coupon? Coupon = _context.Coupons.FirstOrDefault(w => w.CouponId == id);
        if (Coupon != null)
        {
            _context.Remove(Coupon);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }
}