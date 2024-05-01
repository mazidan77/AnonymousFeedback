using AnonymousFeedback.Domian.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Infrastructure.Configs
{
    public class FeedBackConfigs : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasOne(f => f.Sender)
              .WithMany(u => u.SentFeedbacks) 
              .HasForeignKey(f => f.SenderUserName)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Receiver)
             .WithMany(u => u.ReceivedFeedbacks)
             .HasForeignKey(f => f.ReceiverUserName)
               .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
