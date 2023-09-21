// using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CouponClipper.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;  //to use include
namespace CouponClipper.Controllers;

public class CouponController : Controller
{
    private MyContext _context;
    private readonly ILogger<CouponController> _logger;

    public CouponController(ILogger<CouponController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet("coupon/dashboard")]
    public IActionResult Dashboard()
    {
        List<Coupon> AllCoupons = _context.Coupons.Include(coup => coup.Organizer).Include(coup => coup.AllUsers).ToList();
        return View(AllCoupons);
    }


    [HttpGet("coupon/view/{id}")]
    public IActionResult ViewCoupon(int id)
    {
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


    [HttpGet("coupon/new")]
    public IActionResult AddCoupon()
    {
        return View();
    }


    [HttpPost("coupon/create")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            newCoupon.UserId = UserId;
            _context.Add(newCoupon);
            _context.SaveChanges();
            // return RedirectToAction("ViewCoupon", newCoupon.CouponId);
            return RedirectToAction("Dashboard");
            //Todo Change this
            // return ViewCoupon(newCoupon.CouponId);
        }
        return View("AddCoupon");
        // return View ("AddCoupon",newCoupon);
    }


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


    [HttpPost("coupon/{id}/destroy")]
    public IActionResult DeleteCoupon(int id) //goes into dashboard.cshtml
    {
        Coupon? Coupon = _context.Coupons.FirstOrDefault(w => w.CouponId == id);
        if (Coupon != null)
        {
            _context.Remove(Coupon);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }
}